using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{ 
    internal class Server
    {
        static void Main(string[] args)
        {
            AysncEchoServer().Wait();
        }

        async static Task AysncEchoServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2000);
            server.Start();
            while (true)
            {
                TcpClient tc = await server.AcceptTcpClientAsync().ConfigureAwait(false);
                Task.Factory.StartNew(AsyncTcpProcess, tc);
            }
        }
        async static void AsyncTcpProcess(object o)
        {
            TcpClient tc = (TcpClient)o;
            NetworkStream stream = tc.GetStream();
            //비동기 수신
            var buff = new byte[1024];
            var nbytes = await stream.ReadAsync(buff, 0, buff.Length).ConfigureAwait(false);
            if(nbytes > 0)
            {
                //비동기 송신
                await stream.WriteAsync(buff, 0, nbytes).ConfigureAwait(false);
            }
        }
    }
}
