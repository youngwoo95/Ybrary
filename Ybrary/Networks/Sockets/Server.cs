using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Ybrary.Networks.MQTT;

namespace Ybrary.Networks.Sockets
{
    /// <summary>
    /// 델리게이트 선언 - 이벤트핸들러 호출
    /// </summary>
    /// <param name="message"></param>
    public delegate string delSocketServer(string message);

    public class Server
    {
        /// <summary>
        /// 이벤트 핸들러 - 클라이언트 수신 message 반환용
        /// </summary>
        public event delSocketServer ReceiveHandler;
        public Socket client;

        /// <summary>
        /// Socket 서버 실행
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task Start(int port)
        {
            // Socket EndPoint 설정 (모든 IpAddress, 지정된 port)
            var ipep = new IPEndPoint(IPAddress.Any, port);
            
            // socket 인스턴스 생성
            using(Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                // 서버 소켓에 EndPoint 설정
                server.Bind(ipep);
                // 클라이언트 소켓 대기 버퍼
                server.Listen(20);
                
#if DEBUG
                // 콘솔 출력
                Console.WriteLine($"Server Start... Port Number : {ipep.Port}");
#endif
                // server Accept를 Task로 병렬 처리(비동기 처리)
                var task = new Task(() =>
                {
                    // 무한 루프
                    while (true)
                    {
                        // 클라이언트로 부터 접속 대기
                        client = server.Accept();
                        
                        new Task(() =>
                        {
                            // 클라이언트 EndPoint 정보 취득
                            var ip = client.RemoteEndPoint as IPEndPoint;
#if DEBUG
                            // 콘솔 출력 - 접속 ip와 접속 시간
                            Console.WriteLine($"Client : (From: {ip.Address.ToString()}:{ip.Port}, Connection time: {DateTime.Now})");
#endif
                            // 클라이언트로 접속 메시지를 byte로 변환하여 송신
                            client.Send(Encoding.ASCII.GetBytes("Connection> ..\r\n"));
                            // 메시지 버퍼
                            var sb = new StringBuilder();
                            // 종료되면 자동 client 종료
                            using (client)
                            {
                                // 무한 루프
                                while (true)
                                {
                                    // 통신 바이너리 버퍼
                                    var binary = new Byte[1024];
                                    // 클라이언트로부터 메시지 대기
                                    client.Receive(binary);
                                    // 클라이언트로 받은 메시지를 String으로 변환
                                    string receive = Encoding.ASCII.GetString(binary);
                                    // 메시지 공백(\0)을 제거
                                    sb.Append(receive.Trim('\0'));
                                    // 메시지 총 내용이 2글자 이상이고 개행(\r\n)이 발생하면
                                    if(sb.Length > 2 && sb[sb.Length -2] == '\r' && sb[sb.Length -1] == '\n')
                                    {
                                        // 메시지 버퍼의 내용을 String으로 변환
                                        receive = sb.ToString().Replace("\n", "").Replace("\r", "");

                                        // 메시지 내용이 공백이라면 계속 메시지 대기 상태로
                                        if (String.IsNullOrWhiteSpace(receive))
                                        {
                                            continue;
                                        }
                                        // 메시지 내용이 EXIT라면 무한 루프 종료(즉, 서버 종료)
                                        else if("EXIT".Equals(receive, StringComparison.OrdinalIgnoreCase))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            // 이벤트 호출
                                            ReceiveHandler(receive);
#if DEBUG
                                            // 메시지 내용을 콘솔에 표시
                                            Console.WriteLine($"Message : {receive}");
#endif
                                            // 버퍼 초기화
                                            sb.Length = 0;
                                            // 클라이언트로 메시지 송신
                                            //client.Send(Encoding.ASCII.GetBytes(receive));
                                        }
                                    }
                                }
#if DEBUG
                                // 콘솔 출력 - 접속 종료 메시지
                                Console.WriteLine($"Disconnected : (From : {ip.Address.ToString()}:{ip.Port}, Connection time: {DateTime.Now})");
#endif
                            }
                            // Task 실행
                        }).Start();

                        // 서버 -> 클라이언트 메시지 보내는곳
                        while (true)
                        {
                            // 콘솔 입력을 받는다.
                            var msg = Console.ReadLine();
                            // client에게 메시지 송신
                            client.Send(Encoding.ASCII.GetBytes(msg+"\r\n"));
                            // 메시지 내용이 exit라면 무한 루프 종료(즉 서버, 종료)
                            if("EXIT".Equals(msg, StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }
                        }

                    }
                });
                // Task 실행
                task.Start();
                // 대기
                await task;
            }
        }

        /// <summary>
        /// 서버 종료
        /// </summary>
        public void Stop()
        {
            client.Close();
            client.Dispose();
        }
    }
}
