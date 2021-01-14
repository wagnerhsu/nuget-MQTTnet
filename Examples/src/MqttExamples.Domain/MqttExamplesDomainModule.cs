using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MqttExamples
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(MqttExamplesDomainSharedModule)
    )]
    public class MqttExamplesDomainModule : AbpModule
    {

    }
}
