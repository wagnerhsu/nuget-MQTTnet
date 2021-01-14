using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace MqttExamples.MongoDB
{
    public class MqttExamplesMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public MqttExamplesMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}