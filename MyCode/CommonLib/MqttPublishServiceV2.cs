using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wagner.Framework.WxAsync;

namespace CommonLib
{
    public class MqttPublishServiceV2
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();
        private string _ip;
        private int _port;
        private string _clientId;
        private IMqttFactory _factory;
        IMqttClient _mqttClient;
        IMqttClientOptions _options;

        public MqttPublishServiceV2(string ip, int port, string clientId)
        {
            _ip = ip;
            _port = port;
            _clientId = clientId;
            _factory = new MqttFactory();
            _options = new MqttClientOptionsBuilder()
                       .WithClientId(_clientId)
                       .WithTcpServer(_ip, _port)
                       .WithCleanSession(true)
                       .Build();

            _mqttClient = _factory.CreateMqttClient();
        }

        public void Publish(string topic, byte[] data)
        {
            AsyncUtil.RunSync(() =>
                PublishAsync(topic, data));
        }

        private async Task PublishAsync(string topic, byte[] data)
        {
            if (!_mqttClient.IsConnected)
            {
                await _mqttClient.ConnectAsync(_options);
            }
            // Publish an application message
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(data)
                .WithAtMostOnceQoS()
                .Build();
            Logger.Debug($"Publish...:{topic}");

            await _mqttClient.PublishAsync(applicationMessage);

        }
    }
}
