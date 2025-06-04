using Volo.Abp.Modularity;

namespace MokebManagerV2;

public abstract class MokebManagerV2ApplicationTestBase<TStartupModule> : MokebManagerV2TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
