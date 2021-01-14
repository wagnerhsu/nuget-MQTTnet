using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace MqttExamples
{
    [DependsOn(
        typeof(MqttExamplesDomainModule),
        typeof(MqttExamplesApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MqttExamplesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MqttExamplesApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MqttExamplesApplicationModule>(validate: true);
            });
        }
    }
}
