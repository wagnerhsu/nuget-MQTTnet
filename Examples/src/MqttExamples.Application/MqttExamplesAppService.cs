using MqttExamples.Localization;
using Volo.Abp.Application.Services;

namespace MqttExamples
{
    public abstract class MqttExamplesAppService : ApplicationService
    {
        protected MqttExamplesAppService()
        {
            LocalizationResource = typeof(MqttExamplesResource);
            ObjectMapperContext = typeof(MqttExamplesApplicationModule);
        }
    }
}
