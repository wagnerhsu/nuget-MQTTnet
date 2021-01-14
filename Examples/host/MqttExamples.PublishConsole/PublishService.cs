using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MqttExamples.PublishConsole
{
    public class PublishService : ITransientDependency
    {
        private readonly ILogger<PublishService> _logger;

        private IManagedMqttClient managedMqttClient;
        private IManagedMqttClientOptions options;
        private string currentDirectory;

        public PublishService(ILogger<PublishService> logger)
        {
            currentDirectory = Directory.GetCurrentDirectory();
            this._logger = logger;
            // Create TCP based options using the builder.
            options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(new MqttClientOptionsBuilder()
                .WithClientId($"PublishService-{Guid.NewGuid()}")
                .WithTcpServer("192.168.0.34")
                .WithCleanSession()
                .Build())
                .Build();
            managedMqttClient = new MqttFactory().CreateManagedMqttClient();
        }

        public async Task RunAsync()
        {
            string json = File.ReadAllText(Path.Combine(currentDirectory, @"Data\VitalSign.json"));
            await managedMqttClient.StartAsync(options);
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("vitalsign01")
                .WithPayload(json)
                .WithAtMostOnceQoS()
                .Build();
            for (int i = 0; i < 1000; i++)
            {
                _logger.LogDebug($"# {i}");
                await managedMqttClient.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken
                await Task.Delay(3000);
            }
            await managedMqttClient.StopAsync();
        }
    }
}