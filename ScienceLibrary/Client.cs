using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Science_Library;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Linq;
using Client_Code;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Client_Code
{
    public class Client
    {
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private TcpClient client = new TcpClient();
        public bool isitCon = false;
        public static Client a = new Client();

       
            public async Task Run()
            {
                try
                {
                    using (client = new TcpClient())
                    {
                        cancellationTokenSource = new CancellationTokenSource();
                        CancellationToken cancellationToken = cancellationTokenSource.Token;

                        string serverIP = "192.168.0.67";
                        int serverPort = 222;

                        while (true)
                        {
                            try
                            {
                                if (!client.Connected)
                                {
                                    await client.ConnectAsync(serverIP, serverPort);
                                }

                                // 클라이언트가 종료되지 않도록 서버 응답을 기다립니다.
                                while (client.Connected)
                                {
                                    await Task.Delay(1000);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("연결 오류: " + ex.Message);
                                // 연결이 끊어진 경우 재연결 시도
                                await Task.Delay(5000); // 일정한 지연 시간 후 재연결 시도
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Application.Exit();
                }
            }

        // 이전 코드 생략...

        public async Task SendDBFile(string filePath)
        {
            try
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await client.GetStream().WriteAsync(buffer, 0, bytesRead);
                    }

                    // 파일 전송 후 FlushAsync()를 호출하여 데이터가 완전히 전송될 때까지 대기합니다.
                    await client.GetStream().FlushAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB 파일 전송 오류: " + ex.Message);
            }
        }







        public async Task S_login(string studentID,string password)
        {

            string loginInfo = $"{studentID},{password}\n";
            
            byte[] data = Encoding.UTF8.GetBytes(loginInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }

        public async Task S_signup(string studentID, string name, string password)
        {
            string signupInfo = $"{studentID},{name},{password}\n";
            byte[] data = Encoding.UTF8.GetBytes(signupInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }

        public async Task S_num(string seat)
        {
            string numInfo = $"{seat}\n";
            byte[] data = Encoding.UTF8.GetBytes(numInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }
        public async Task S_String_Async(string message)
        {
            string stringInfo = $"{message}\n";
            byte[] data = Encoding.UTF8.GetBytes(stringInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveStringFromServer()
        {
            byte[] buffer = new byte[1024];
            StringBuilder sb = new StringBuilder();

            // 서버로부터 데이터를 읽어옵니다.
            int bytesRead;
            while ((bytesRead = await client.GetStream().ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                sb.Append(data);

                // 데이터의 끝을 확인하여 반복문을 종료합니다.
                if (data.EndsWith("\n"))
                {
                    break;
                }
            }

            string receivedData = sb.ToString().Trim();
            return receivedData;
        }
        public bool ProcessReceivedData(string receivedData)
        {
            // 문자열 값에 따라 처리 로직을 구현합니다.
            // 예시: "true"일 경우 true 반환, 그 외의 값은 false 반환
            if (receivedData.Trim().ToLower() == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task ReceiveDBFile(string savePath)
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
        }
        public void DeleteDBFileInFolder(string filePath)
        {
            try
            {
                File.Delete(filePath);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB 파일 삭제 오류: {ex.Message}");
            }
        }




    }







}


