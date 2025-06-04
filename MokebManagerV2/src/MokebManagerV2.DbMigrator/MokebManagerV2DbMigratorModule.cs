using MokebManagerV2.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MokebManagerV2.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MokebManagerV2EntityFrameworkCoreModule),
    typeof(MokebManagerV2ApplicationContractsModule)
    )]
public class MokebManagerV2DbMigratorModule : AbpModule
{
}
