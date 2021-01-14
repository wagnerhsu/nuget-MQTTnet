using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MqttExamples.EntityFrameworkCore
{
    [ConnectionStringName(MqttExamplesDbProperties.ConnectionStringName)]
    public class MqttExamplesDbContext : AbpDbContext<MqttExamplesDbContext>, IMqttExamplesDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public MqttExamplesDbContext(DbContextOptions<MqttExamplesDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMqttExamples();
        }
    }
}