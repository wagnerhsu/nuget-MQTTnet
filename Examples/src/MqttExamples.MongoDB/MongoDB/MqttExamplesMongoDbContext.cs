using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MqttExamples.MongoDB
{
    [ConnectionStringName(MqttExamplesDbProperties.ConnectionStringName)]
    public class MqttExamplesMongoDbContext : AbpMongoDbContext, IMqttExamplesMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureMqttExamples();
        }
    }
}