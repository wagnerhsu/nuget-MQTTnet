using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace MqttExamples
{
    [DependsOn(
        typeof(MqttExamplesDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class MqttExamplesApplicationContractsModule : AbpModule
    {

    }
}
