using Volo.Abp.Modularity;

namespace MqttExamples
{
    [DependsOn(
        typeof(MqttExamplesApplicationModule),
        typeof(MqttExamplesDomainTestModule)
        )]
    public class MqttExamplesApplicationTestModule : AbpModule
    {

    }
}
