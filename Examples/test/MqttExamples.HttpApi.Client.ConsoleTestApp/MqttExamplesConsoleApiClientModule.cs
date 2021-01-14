using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MqttExamples
{
    [DependsOn(
        typeof(MqttExamplesHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MqttExamplesConsoleApiClientModule : AbpModule
    {
        
    }
}
