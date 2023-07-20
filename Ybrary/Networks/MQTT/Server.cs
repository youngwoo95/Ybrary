using MQTTnet;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ybrary.Networks.MQTT
{
    public class Server
    {
        /// <summary>
        /// 서버 브로커
        /// </summary>
        private static MqttServer broker;

        /// <summary>
        /// MQTT 서버 실행
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static async Task ServerStart(int port)
        {
            try
            {
                MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                    .WithDefaultEndpoint()
                    .WithDefaultEndpointPort(port)
                    .WithConnectionBacklog(100);

                broker = new MqttFactory().CreateMqttServer(options.Build());

                broker.InterceptingPublishAsync += Server_InterceptingPublishAsync;

                await broker.StartAsync();
#if DEBUG
                Console.WriteLine("MQTT 서버 시작...");
#endif

                Task Server_InterceptingPublishAsync(InterceptingPublishEventArgs arg)
                {
                    var payload = arg.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(arg.ApplicationMessage?.Payload);

                    Console.WriteLine($"[{DateTime.Now}] Clinet : {arg.ClientId} / Topic : {arg.ApplicationMessage?.Topic} / Contents : {payload}");

                    return Task.CompletedTask;
                }
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }

        /// <summary>
        /// MQTT 서버 종료
        /// </summary>
        /// <returns></returns>
        public static async Task ServerStop()
        {
            try
            {
                await broker.StopAsync();
                broker.Dispose();
#if DEBUG
                Console.WriteLine("MQTT 서버 종료...");
#endif
            }catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }
    }
}
