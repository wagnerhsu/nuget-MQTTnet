using System.Threading.Tasks;
using MqttExamples.Localization;
using Volo.Abp.UI.Navigation;

namespace MqttExamples.Blazor.Host
{
    public class MqttExamplesHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<MqttExamplesResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "MqttExamples.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
