using Localization.Resources.AbpUi;
using MqttExamples.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace MqttExamples
{
    [DependsOn(
        typeof(MqttExamplesApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MqttExamplesHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MqttExamplesHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MqttExamplesResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
