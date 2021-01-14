using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MqttExamples.EntityFrameworkCore
{
    [DependsOn(
        typeof(MqttExamplesDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class MqttExamplesEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MqttExamplesDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}