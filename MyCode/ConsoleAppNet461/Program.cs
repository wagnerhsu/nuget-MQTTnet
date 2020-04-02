using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace ConsoleAppNet461
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPublish();
            Console.WriteLine("Press ENTER to exit");
            Console.Read();
        }

        private static void TestPublish()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
            var mqttSetting = configuration.GetSection("MqttSetting").Get<Dgw.Netstandard.Common.Models.MqttConfigurationModel>();
            Console.WriteLine(JsonConvert.SerializeObject(mqttSetting));
        }
    }
}
