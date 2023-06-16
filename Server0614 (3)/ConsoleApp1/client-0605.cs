using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Science_Library
{
    class ConsoleClient
    {
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private TcpClient client;

        public async Task menu()
        {
            Console.WriteLine("1.회원가입");
            Console.WriteLine("2.로그인");
            string menu_1 = Console.ReadLine();
            int mn_1 = int.Parse(menu_1);
            switch (mn_1)
            {
                case 1:
                    await Sign_up();
                    break;

                case 2:
                    await Log_in();
                    break;

                default:
                    Console.WriteLine("Invalid value");
                    break;
            }
        }

        public async Task Run()
        {
            try
            {
                using (client = new TcpClient())
                {
                    cancellationTokenSource = new CancellationTokenSource();
                    CancellationToken cancellationToken = cancellationTokenSource.Token;

                    string serverIP = "192.168.0.5";
                    int serverPort = 1;

                    await client.ConnectAsync(serverIP, serverPort);

                    Console.WriteLine("서버 연결 성공. 이제 메시지를 보낼 수 있습니다.");

                    // 클라이언트로부터의 메시지를 항시 출력
                    Task.Factory.StartNew(() => ReceiveMessagesAsync());

                    await menu();

                    // 클라이언트가 종료되지 않도록 서버 응답을 기다립니다.
                    while (true)
                    {
                        await Task.Delay(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류 발생: " + ex.Message);
            }
        }

        private async Task S_Log_in_Async(string message, string studentID, string name, string password)
        {
            // 학번과 이름을 전달하기 위해 message를 수정합니다.
            string loginInfo = $"{message},{studentID},{name},{password}\n";
            byte[] data = Encoding.UTF8.GetBytes(loginInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }



        private async Task S_Sign_up_Async(string message, string studentID, string name, string password)
        {
            string signupInfo = $"{message},{studentID},{name},{password}\n";
            byte[] data = Encoding.UTF8.GetBytes(signupInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }

        private async Task S_Num_Async(string message)
        {
            string numInfo = $"{message}\n";
            byte[] data = Encoding.UTF8.GetBytes(numInfo);
            await client.GetStream().WriteAsync(data, 0, data.Length);
        }

        private async Task SendNumberToServer()
        {
            try
            {
               
                string numberInput = Console.ReadLine();

                // 서버로 숫자 전송
                await S_Num_Async(numberInput);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류 발생: " + ex.Message);
            }
        }
      

        public async Task ReceiveMessagesAsync()
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string receivedMessage = "";

            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead <= 0)
                {
                    // 서버 연결이 종료된 경우
                    break;
                }

                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                receivedMessage += data;

                while (receivedMessage.Contains("\n"))
                {
                    int newlineIndex = receivedMessage.IndexOf("\n");
                    string message = receivedMessage.Substring(0, newlineIndex).Trim();
                    receivedMessage = receivedMessage.Substring(newlineIndex + 1);

                    Console.WriteLine("[서버] : " + message);

                    if (message == "회원가입 성공")
                    {
                        Console.WriteLine("회원가입에 성공했습니다.");
                        await menu();
                        return;
                    }
                    if (message == "2.테이블 비우기")
                    {
                        Console.WriteLine("숫자 입력");
                        await SendNumberToServer();
                        while (true)
                        {
                            await Task.Delay(1000);
                        }

                        return;
                    }
                }
            }
        }


        public async Task Log_in()
        {
            Console.WriteLine("학번을 입력해주세요");
            string studentID = Console.ReadLine();

            Console.WriteLine("이름을 입력해주세요");
            string name = Console.ReadLine();

            Console.WriteLine("비밀번호를 입력하세요");
            string password = Console.ReadLine();
            
            await S_Log_in_Async("Log_in", studentID, name,password);
            while (true)
            {
                await Task.Delay(1000);
            }
        }

        public async Task Sign_up()
        {
            Console.WriteLine("학번을 입력해주세요");
            string studentID = Console.ReadLine();

            Console.WriteLine("이름을 입력해주세요");
            string name = Console.ReadLine();

            Console.WriteLine("비밀번호를 입력하세요");
            string password = Console.ReadLine();

            Console.WriteLine("비밀번호를 한번 더 입력하세요");
            string password_1 = Console.ReadLine();

            if (password != password_1)
            {
                Console.WriteLine("비밀번호를 잘못 입력하셨습니다.");
                await menu(); // 비밀번호가 일치하지 않을 경우 다시 메뉴를 호출
            }
            else
            {
                await S_Sign_up_Async("Sign_up", studentID, name, password);

                // 회원가입 후 서버 응답을 기다립니다.
                while (true)
                {
                    await Task.Delay(1000);
                }
            }
        }

        static async Task Main(string[] args)
        {
            ConsoleClient client = new ConsoleClient();
            await client.Run();

            // 프로그램이 종료되지 않도록 콘솔창 유지
            Console.ReadLine();
        }
    }
}
