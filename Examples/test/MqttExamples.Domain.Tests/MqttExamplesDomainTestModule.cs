using MqttExamples.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MqttExamples
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(MqttExamplesEntityFrameworkCoreTestModule)
        )]
    public class MqttExamplesDomainTestModule : AbpModule
    {
        
    }
}
