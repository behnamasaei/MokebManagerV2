using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MokebManagerV2.Data;

/* This is used if database provider does't define
 * IMokebManagerV2DbSchemaMigrator implementation.
 */
public class NullMokebManagerV2DbSchemaMigrator : IMokebManagerV2DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
