using MqttExamples.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MqttExamples.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MqttExamplesPageModel : AbpPageModel
    {
        protected MqttExamplesPageModel()
        {
            LocalizationResourceType = typeof(MqttExamplesResource);
            ObjectMapperContext = typeof(MqttExamplesWebModule);
        }
    }
}