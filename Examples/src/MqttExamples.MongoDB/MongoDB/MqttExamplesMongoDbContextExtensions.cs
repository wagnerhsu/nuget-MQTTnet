using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace MqttExamples.MongoDB
{
    public static class MqttExamplesMongoDbContextExtensions
    {
        public static void ConfigureMqttExamples(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MqttExamplesMongoModelBuilderConfigurationOptions(
                MqttExamplesDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}