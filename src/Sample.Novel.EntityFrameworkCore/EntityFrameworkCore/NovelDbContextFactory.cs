using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Sample.Novel.EntityFrameworkCore.EntityFrameworkCore
{
    public class NovelDbContextFactory : IDesignTimeDbContextFactory<NovelDbContext>
    {
        public NovelDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<NovelDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new NovelDbContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Sample.Novel.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
