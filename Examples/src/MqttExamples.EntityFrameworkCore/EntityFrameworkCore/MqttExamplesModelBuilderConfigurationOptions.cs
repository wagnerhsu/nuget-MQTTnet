using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MqttExamples.EntityFrameworkCore
{
    public class MqttExamplesModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MqttExamplesModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}