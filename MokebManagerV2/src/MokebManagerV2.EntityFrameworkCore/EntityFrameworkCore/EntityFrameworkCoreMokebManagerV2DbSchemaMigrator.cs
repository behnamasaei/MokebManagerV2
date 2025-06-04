using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MokebManagerV2.Data;
using Volo.Abp.DependencyInjection;

namespace MokebManagerV2.EntityFrameworkCore;

public class EntityFrameworkCoreMokebManagerV2DbSchemaMigrator
    : IMokebManagerV2DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMokebManagerV2DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MokebManagerV2DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MokebManagerV2DbContext>()
            .Database
            .MigrateAsync();
    }
}
