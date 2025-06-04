using Volo.Abp.Modularity;

namespace MokebManagerV2;

[DependsOn(
    typeof(MokebManagerV2DomainModule),
    typeof(MokebManagerV2TestBaseModule)
)]
public class MokebManagerV2DomainTestModule : AbpModule
{

}
