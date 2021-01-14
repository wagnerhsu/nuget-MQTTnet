using Microsoft.Extensions.DependencyInjection;
using MqttExamples.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace MqttExamples.Blazor
{
    [DependsOn(
        typeof(MqttExamplesHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MqttExamplesBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MqttExamplesBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MqttExamplesBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new MqttExamplesMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(MqttExamplesBlazorModule).Assembly);
            });
        }
    }
}