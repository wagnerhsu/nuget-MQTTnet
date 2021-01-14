using MqttExamples.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MqttExamples.Pages
{
    public abstract class MqttExamplesPageModel : AbpPageModel
    {
        protected MqttExamplesPageModel()
        {
            LocalizationResourceType = typeof(MqttExamplesResource);
        }
    }
}