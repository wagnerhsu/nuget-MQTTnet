using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MqttExamples.EntityFrameworkCore
{
    public class MqttExamplesHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<MqttExamplesHttpApiHostMigrationsDbContext>
    {
        public MqttExamplesHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MqttExamplesHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("MqttExamples"));

            return new MqttExamplesHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
