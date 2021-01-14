using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MqttExamples.SubscribeConsole
{
    public class SubscribeService : ITransientDependency, IDisposable
    {
        private IManagedMqttClient _managedMqttClient;
        private IManagedMqttClientOptions _options;
        ILogger<SubscribeService> _logger;

        public SubscribeService(ILogger<SubscribeService> logger)
        {
            this._logger = logger;

            // Create TCP based options using the builder.
            var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithClientId($"SubscribeService-{Guid.NewGuid()}")
                .WithTcpServer("192.168.0.34")
                .WithCleanSession()
                .Build();
            _options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(mqttClientOptions)
                .WithAutoReconnect()
                .WithAutoReconnectDelay(new TimeSpan(0,2,0))
                .Build();
           
            _managedMqttClient = new MqttFactory().CreateManagedMqttClient();
        }

        public void Dispose()
        {
            Volo.Abp.Threading.AsyncHelper.RunSync(()=>_managedMqttClient.StopAsync());
            _managedMqttClient.Dispose();
            _logger.LogInformation($"{nameof(SubscribeService)}.Dispose");
        }

        public async Task RunAsync()
        {
            _managedMqttClient.UseApplicationMessageReceivedHandler((e) => {
                _logger.LogDebug(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
            });
            await _managedMqttClient.StartAsync(_options);
            await _managedMqttClient.SubscribeAsync(new MqttTopicFilter
            {
                Topic = "#",
                QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce
            });
            await Task.CompletedTask;
        }
    }
}
