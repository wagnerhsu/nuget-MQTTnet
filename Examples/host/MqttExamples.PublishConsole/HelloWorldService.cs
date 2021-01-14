using System;
using Volo.Abp.DependencyInjection;

namespace MqttExamples.PublishConsole
{
    public class HelloWorldService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
