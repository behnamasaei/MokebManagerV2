using Volo.Abp.Modularity;

namespace MokebManagerV2;

/* Inherit from this class for your domain layer tests. */
public abstract class MokebManagerV2DomainTestBase<TStartupModule> : MokebManagerV2TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
