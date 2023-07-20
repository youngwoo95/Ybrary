using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Ybrary.Networks.MQTT
{
    public class Client
    {
        /// <summary>
        /// 메시지 버퍼
        /// </summary>
        private static byte[] message;

        /// <summary>
        /// MQTT Client 객체
        /// </summary>
        public static IMqttClient mqttClient;

        /// <summary>
        /// MQTT 클라이언트 시작
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="topic"></param>
        /// <param name="clientid"></param>
        /// <returns></returns>
        public static async Task ClientStart(string ip, int port, string topic, string clientid)
        {
            try
            {
                // MQTT factory
                MqttFactory factory = new MqttFactory();

                // MQTT client
                mqttClient = factory.CreateMqttClient();

                // MQTT client options
                MqttClientOptions options = new MqttClientOptionsBuilder()
                        .WithTcpServer(ip, port)
                        .WithClientId(clientid)
                        .WithCleanSession(true)
                        .Build();

                MqttClientConnectResult connectresult = await mqttClient.ConnectAsync(options);

                if (connectresult.ResultCode == MqttClientConnectResultCode.Success)
                {
#if DEBUG
                    Console.WriteLine("MQTT 클라이언트 연결성공...");
#endif

                    //await mqttClient.SubscribeAsync(topic);

                    mqttClient.ApplicationMessageReceivedAsync += e =>
                    {
                        message = e.ApplicationMessage?.Payload;

                        return Task.CompletedTask;
                    };
                }
            }catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }

        /// <summary>
        /// 구독 (Subscribe)
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public static async Task SubScribe(string topic)
        {
            try
            {
                await mqttClient.SubscribeAsync(topic);
            }
            catch (Exception ex) 
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }

        /// <summary>
        /// 구독 취소
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public static async Task UnSubScribe(string topic)
        {
            try
            {
                await mqttClient.UnsubscribeAsync(topic);
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }

        /// <summary>
        /// 게시 (Publish)
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task Publish(string topic, string message)
        {
            try
            {
                MqttApplicationMessage publish = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(message)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .WithRetainFlag(true)
                    .Build();

                await mqttClient.PublishAsync(publish);
                await Task.Delay(1000);
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }
        

        /// <summary>
        /// byte code 반환
        /// </summary>
        /// <returns></returns>
        public static byte[] GetMessage()
        {
            try
            {
                return message;
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// byte 코드 string 변환값 반환
        /// </summary>
        /// <returns></returns>
        public static string GetConvertMessage()
        {
            try
            {
                return Encoding.UTF8.GetString(message);
            }
            catch(Exception ex)
            {
#if  DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }
        }
    }
}
