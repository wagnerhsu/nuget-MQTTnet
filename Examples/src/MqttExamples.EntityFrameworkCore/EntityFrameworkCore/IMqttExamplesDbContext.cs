using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MqttExamples.EntityFrameworkCore
{
    [ConnectionStringName(MqttExamplesDbProperties.ConnectionStringName)]
    public interface IMqttExamplesDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}