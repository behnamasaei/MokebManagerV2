using System.Threading.Tasks;

namespace MokebManagerV2.Data;

public interface IMokebManagerV2DbSchemaMigrator
{
    Task MigrateAsync();
}
