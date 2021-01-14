using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MqttExamples.EntityFrameworkCore
{
    public class MqttExamplesHttpApiHostMigrationsDbContext : AbpDbContext<MqttExamplesHttpApiHostMigrationsDbContext>
    {
        public MqttExamplesHttpApiHostMigrationsDbContext(DbContextOptions<MqttExamplesHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureMqttExamples();
        }
    }
}
