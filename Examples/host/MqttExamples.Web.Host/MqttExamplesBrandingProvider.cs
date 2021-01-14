using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MqttExamples
{
    [Dependency(ReplaceServices = true)]
    public class MqttExamplesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MqttExamples";
    }
}
