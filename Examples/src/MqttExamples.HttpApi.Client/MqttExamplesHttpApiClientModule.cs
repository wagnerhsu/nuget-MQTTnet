using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace MqttExamples
{
    [DependsOn(
        typeof(MqttExamplesApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MqttExamplesHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "MqttExamples";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MqttExamplesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
