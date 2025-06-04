using Volo.Abp.Modularity;

namespace MokebManagerV2;

[DependsOn(
    typeof(MokebManagerV2ApplicationModule),
    typeof(MokebManagerV2DomainTestModule)
)]
public class MokebManagerV2ApplicationTestModule : AbpModule
{

}
