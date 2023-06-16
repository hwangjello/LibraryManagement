using System;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {
        private string connectionString;
        DatabaseConnector connector;

        static async Task Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //await connector.CreateDatabase();

            await AsyncEchoServer();
            string savePath = "C:\\Users\\jmhwa\\LibraryManagement\\ScienceLibrary\\DB\\info.db"; 

            Console.WriteLine("서버가 종료되었습니다. 아무 키나 누르세요...");
            Console.ReadKey();
        }

        async static Task AsyncEchoServer()
        {
            string serverIP = "192.168.50.83";
            int serverPort = 9012;
            TcpListener server = new TcpListener(IPAddress.Parse(serverIP), serverPort);
            server.Start();
            Console.WriteLine("서버가 시작되었습니다.");

            while (true)
            {
                TcpClient tc = await server.AcceptTcpClientAsync();

                Task.Factory.StartNew(() => AsyncTcpProcess(tc));
            }
        }

        async static Task SendToClientAsync(TcpClient client, string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
            await stream.FlushAsync(); 
        }

        async static Task AsyncTcpProcess(object o)
        {
            TcpClient tc = (TcpClient)o;
            NetworkStream stream = tc.GetStream();
            var buff = new byte[1024];

            StringBuilder sb = new StringBuilder();
            int bytesRead;
            do
            {
                bytesRead = await stream.ReadAsync(buff, 0, buff.Length);
                sb.Append(Encoding.UTF8.GetString(buff, 0, bytesRead));
            } while (stream.DataAvailable);

            string receivedData = sb.ToString();

            Console.WriteLine("Received data: " + receivedData);

            string dbFilePath = "C:\\Users\\jmhwa\\LibraryManagement\\ScienceLibrary\\DB\\info.db"; 

            byte[] dbFileBytes = File.ReadAllBytes(dbFilePath);

            await SendToClientAsync(tc, dbFileBytes.Length.ToString());
            await stream.FlushAsync(); 

            byte[] ackBuffer = new byte[1024];
            int ackBytesRead = await stream.ReadAsync(ackBuffer, 0, ackBuffer.Length);
            string ackData = Encoding.UTF8.GetString(ackBuffer, 0, ackBytesRead);

            if (ackData == "ACK")
            {
                await SendToClientAsync(tc, Convert.ToBase64String(dbFileBytes));
                await stream.FlushAsync(); 
                tc.Close();

                string savePath = "C:\\Users\\jmhwa\\LibraryManagement\\ScienceLibrary\\DB\\info.db";
                await ReceiveDBFile(tc, savePath);
            }
        }

        public static async Task ReceiveDBFile(TcpClient client, string savePath)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            using (FileStream fileStream = File.Create(savePath))
            {
                while ((bytesRead = await client.GetStream().ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
            Console.WriteLine("파일받음");
        }
    }
}
