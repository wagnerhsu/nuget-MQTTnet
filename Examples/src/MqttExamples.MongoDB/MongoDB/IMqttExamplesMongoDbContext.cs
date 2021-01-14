using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MqttExamples.MongoDB
{
    [ConnectionStringName(MqttExamplesDbProperties.ConnectionStringName)]
    public interface IMqttExamplesMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
