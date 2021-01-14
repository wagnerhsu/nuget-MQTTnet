using MqttExamples.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MqttExamples
{
    public abstract class MqttExamplesController : AbpController
    {
        protected MqttExamplesController()
        {
            LocalizationResource = typeof(MqttExamplesResource);
        }
    }
}
