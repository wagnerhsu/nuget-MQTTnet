using System;
using Volo.Abp.DependencyInjection;

namespace MqttExamples.SubscribeConsole
{
    public class HelloWorldService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
