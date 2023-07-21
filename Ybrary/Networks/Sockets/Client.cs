using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ybrary.Networks.Sockets
{
    /// <summary>
    /// 이벤트 호출을 위한 델리게이트 선언
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public delegate string delSocketClient(string message);

    public class Client
    {
        /// <summary>
        /// 서버로 메시지가 들어오면 발생하는 이벤트 핸들러 선언
        /// </summary>
        public event delSocketClient ReceiveHandler;

        /// <summary>
        /// 클라이언트 소켓 인스턴스
        /// </summary>
        public Socket client;

        public void Start(string ip, int port)
        {
            // Socket EndPoint 설정
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            // 소켓 인스턴스 생성
            using (client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                // 소켓 접속
                client.Connect(ipep);
                // 접속이 되면 Task로 병렬 처리

                new Task(() =>
                {
                    try
                    {
                        // 메시지 버퍼
                        StringBuilder sb = new StringBuilder();
                        
                        // 종료되면 자동 client 종료
                        // 무한 루프
                        while (true)
                        {
                            // 통신 바이너리 버퍼
                            var binary = new Byte[1024];
                            // 서버로부터 메시지 대기
                            client.Receive(binary);
                            // 서버로 받은 메시지를 String으로 변환
                            var receive = Encoding.ASCII.GetString(binary);
                            // 메시지 내용이 공백이라면 계속 메시지 대기 상태로
                            sb.Append(receive.Trim('\0'));

                            if(sb.Length>2 && sb[sb.Length-2] == '\r' && sb[sb.Length-1] == '\n')
                            {
                                receive = sb.ToString().Replace("\n", "").Replace("\r", "");

                                if (String.IsNullOrWhiteSpace(receive))
                                {
                                    continue;
                                }
                                else
                                {
#if DEBUG
                                    // 서버로 받은 메시지 출력
                                    Console.WriteLine(receive);
#endif
                                    // 이벤트 핸들러 호출
                                    ReceiveHandler(receive);
                                    
                                    // 버퍼 초기화
                                    sb.Length = 0;
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
#if DEBUG
                        // 접속 끊김이 발생하면 Exception 발생
                        Console.WriteLine(ex.Message);
#endif
                    }
                }).Start();

                // 유저로부터 메시지 받기 위한 무한 루프
                while (true)
                {
                    // 콘솔 입력을 받음
                    var msg = Console.ReadLine();
                    // 클라이언트로 받은 메시지를 String으로 변환
                    client.Send(Encoding.ASCII.GetBytes(msg + "\r\n"));
                }
#if DEBUG
                // 콘솔 출력 - 접속 종료 메시지
                Console.WriteLine("Disconnected");
#endif
            }
        }

        /// <summary>
        /// 서버 종료
        /// </summary>
        public  void Stop()
        {
            client.Close();
        }

    }
}
