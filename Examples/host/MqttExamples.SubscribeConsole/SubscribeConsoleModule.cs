using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MqttExamples.SubscribeConsole
{

    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class SubscribeConsoleModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

            context.Services.AddHostedService<SubscribeConsoleHostedService>();
        }
    }
}
