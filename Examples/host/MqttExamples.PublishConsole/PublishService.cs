using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MqttExamples.PublishConsole
{
    public class PublishService : ITransientDependency
    {
        private readonly ILogger<PublishService> _logger;
        private readonly IConfiguration _configuration;
        private IManagedMqttClient managedMqttClient;
        private IManagedMqttClientOptions options;
        private string currentDirectory;

        public PublishService(ILogger<PublishService> logger,
            IConfiguration configuration)
        {
            currentDirectory = Directory.GetCurrentDirectory();
            this._logger = logger;
            this._configuration = configuration;
            // Create TCP based options using the builder.
            options = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(new MqttClientOptionsBuilder()
                .WithClientId(_configuration["MqttSettings:Client:ClientId"])
                .WithTcpServer(_configuration["MqttSettings:Client:TcpServerIp"])
                .WithCleanSession()
                .Build())
                .Build();
            managedMqttClient = new MqttFactory().CreateManagedMqttClient();
        }

        public async Task RunAsync()
        {
            string json = File.ReadAllText(Path.Combine(currentDirectory, @"Data\VitalSign.json"));
            await managedMqttClient.StartAsync(options);
            var topics = _configuration.GetSection("MqttSettings:Publish:Topics").Get<List<string>>();
            foreach(var topic in topics)
            {
                var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(json)
                .WithAtMostOnceQoS()
                .Build();
                for (int i = 0; i < 1000; i++)
                {
                    _logger.LogDebug($"# {i}");
                    await managedMqttClient.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken
                    await Task.Delay(3000);
                }
            }
            
            await managedMqttClient.StopAsync();
        }
    }
}