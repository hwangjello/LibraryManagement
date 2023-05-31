using Science_Library;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*********************************************************************************************
 < 필독 사항>
이건 클라이언트를 만드는 기본틀이고 나중에 main 파일에 추가해서 버튼누를때 작동되게 해야함 
일단 만들어진 버튼이 아니더라도 5개 기능을 만들어 봤음. 
버튼으로 연동하는것도 조만간 시행해보겠음.
-김준영-
미완성이니 주석달린 부분 아이디어나 채워서 업데이트 하는식으로 클라이언트 연동합시다. 
아직 동준이가 만든 서버랑은 연결 안해봄. 
ip 따야하는데 주말에 학교 안가봄 ㅋㅎㅋㅎ
 */
namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient a = new ConsoleClient();
            Form Firstform = new Science_Library.Login();
        }

        class ConsoleClient
        {
            TcpClient client = null;
            Thread receiveMessageThread = null;
            ConcurrentBag<string> sendMessageListToView = null;
            ConcurrentBag<string> receiveMessageListToView = null;
            private string name = null;

            public void Run()
            {

                while (true)
                {
                    
                    Console.WriteLine("1.회원가입");
                    Console.WriteLine("2.로그인");
                    Console.WriteLine("3.입실");
                    Console.WriteLine("4.퇴실");
                    Console.WriteLine("세미나실 예약");
                    Console.WriteLine("0.종료");


                    string read = Console.ReadLine();

                    int order = 0;
                    int student_id;
                    int password;


                    if (int.TryParse(read, out order))
                    {
                        switch (order)
                        {
                            case StaticDefine.Sign_up:
                                {

                                    if (client != null)
                                    {
                                        Console.WriteLine("이미 연결되어있습니다.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Connect();
                                    }
                                    Console.WriteLine("1.학번을 입력하세요");
                                    /*if 자연대 학생 리스트.db 와 연동 후 없으면 "자연대 학생만 이용가능합니다", 있으면 비번 입력
*/
                                    int.TryParse(read, out student_id);

                                    Console.WriteLine("1.비밀번호를 입력하세요");
                                    /* 비번 입력시 제외 문자 정해야함 특수문자 안되는걸로 해야할듯 메모리땜시
                                   
*/
                                    int.TryParse(read, out password);

                                    //list 하나 만들어서 가입된 id , password 정해야하고 관리자가 승인해야 로그인 되는지도 정해야함.
                                    // 그리고 만들때 데이터 베이스파일에 저장할지 아니면 list 만들어서 저장할지인데 김준영은 용량 생각시 db가 좋다고 판단중

                                    break;
                                }
                            case StaticDefine.Login:
                                {
                                    if (client == null)
                                    {
                                        Console.WriteLine("먼저 서버와 연결해주세요");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        login_process();
                                    }

                                    break;
                                }
                            case StaticDefine.Enter_sl:
                                {

                                    break;
                                }
                            case StaticDefine.Exit_sl:
                                {

                                    break;
                                }
                            case StaticDefine.Seminar:
                                {

                                    break;
                                }

                            case StaticDefine.EXIT:
                                {
                                    if (client != null)
                                    {
                                        client.Close();
                                    }
                                    receiveMessageThread.Abort();
                                    return;
                                }
                        }
                    }

                    else
                    {
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Console.ReadKey();
                    }
                    Console.Clear();
                    Thread.Sleep(50);
                }
            }






            class StaticDefine
            {
                public const int Sign_up = 1;
                public const int Login = 2;
                public const int Enter_sl = 3;
                public const int Exit_sl = 4;
                public const int Seminar = 5;
                public const int EXIT = 0;
            }

            // 사용자가 메시지를 보내는 기능입니다.
            private void login_process()
            {
                string read = Console.ReadLine();


                int student_id;
                int password; // 여기가 살짝 거슬리는게 같은 변수를 써도 private이라 상관없긴한데 헷갈리면 어쩌지

                string getUserList = string.Format("{0}<GiveMeUserList>", name);
                byte[] getUserByte = Encoding.Default.GetBytes(getUserList);
                client.GetStream().Write(getUserByte, 0, getUserByte.Length);

                Console.WriteLine("1.학번을 입력하세요");
                /*if 자연대 학생 리스트.db 와 연동 후 없으면 "자연대 학생만 이용가능합니다", 있으면 비번 입력
*/
                int.TryParse(read, out student_id);

                Console.WriteLine("1.비밀번호를 입력하세요");
                /* 비번 입력시 제외 문자 정해야함 특수문자 안되는걸로 해야할듯 메모리땜시

*/
                int.TryParse(read, out password);




                string idtosever = string.Format("{0}", student_id);
                string pwtosever = string.Format("{0}", password);

                byte[] byteData_1 = new byte[1024];
                byteData_1 = Encoding.Default.GetBytes(idtosever);
                byte[] byteData_2 = new byte[1024];
                byteData_1 = Encoding.Default.GetBytes(idtosever);


                client.GetStream().Write(byteData_1, 0, byteData_1.Length);
                client.GetStream().Write(byteData_2, 0, byteData_2.Length);
                sendMessageListToView.Add(string.Format("[{0}] id: {1}, password : {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), student_id, password));

                Console.ReadKey();
            }

            // 서버에 접속하는 메서드입니다.
            private void Connect()
            {
                Console.WriteLine("이름을 입력해주세요");

                name = Console.ReadLine();

                string parsedName = "%^&" + name;
                if (parsedName == "%^&")
                {
                    Console.WriteLine("제대로된 이름을 입력해주세요");
                    Console.ReadKey();
                    return;
                }

                client = new TcpClient();
                // 하나의 PC에서 사용하므로 루프백IP를 사용하였습니다.
                // 여러개의 PC에서 사용하려면 서버PC의 실제 IP를 입력해주셔야됩니다.
                client.Connect("127.0.0.1", 9999);

                byte[] byteData = new byte[1024];
                byteData = Encoding.Default.GetBytes(parsedName);
                client.GetStream().Write(byteData, 0, byteData.Length);

                // 서버에 접속하고 서버의 메시지를 받아주는 스레드를 돌려줍니다.
                receiveMessageThread.Start();

                Console.WriteLine("서버연결 성공 이제 Message를 보낼 수 있습니다.");
                Console.ReadKey();
            }
        }
    }
}
