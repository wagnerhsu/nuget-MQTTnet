using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using NLog;
using System.Threading.Tasks;
using Wagner.Framework.WxAsync;

namespace CommonLib
{
    public class MqttPublishService
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();
        private string _ip;
        private int _port;
        private string _clientId;
        private IMqttFactory _factory;

        public MqttPublishService(string ip, int port, string clientId)
        {
            _ip = ip;
            _port = port;
            _clientId = clientId;
            _factory = new MqttFactory();
        }

        public void Publish(string topic, byte[] data)
        {
            Task.Run(async () => {
                await PublishAsync(topic, data);
            });
        }


        public async Task PublishAsync(string topic, byte[] data)
        {
            var options = new MqttClientOptionsBuilder()
                    .WithClientId(_clientId)
                    .WithTcpServer(_ip, _port)
                    .WithCleanSession(true)
                    .Build();

            IMqttClient mqttClient = _factory.CreateMqttClient();
            await mqttClient.ConnectAsync(options);
            // Publish an application message
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(data)
                .WithAtMostOnceQoS()
                .Build();
            Logger.Debug($"Publish...:{topic}");
            await mqttClient.PublishAsync(applicationMessage);
            await mqttClient.DisconnectAsync();
        }
    }
}