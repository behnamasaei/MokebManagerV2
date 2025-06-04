using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MokebManagerV2.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MokebManagerV2DbContextFactory : IDesignTimeDbContextFactory<MokebManagerV2DbContext>
{
    public MokebManagerV2DbContext CreateDbContext(string[] args)
    {
        MokebManagerV2EfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MokebManagerV2DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new MokebManagerV2DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MokebManagerV2.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
