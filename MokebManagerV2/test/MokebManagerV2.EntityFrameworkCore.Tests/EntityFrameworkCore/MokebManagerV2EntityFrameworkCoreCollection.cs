using Xunit;

namespace MokebManagerV2.EntityFrameworkCore;

[CollectionDefinition(MokebManagerV2TestConsts.CollectionDefinitionName)]
public class MokebManagerV2EntityFrameworkCoreCollection : ICollectionFixture<MokebManagerV2EntityFrameworkCoreFixture>
{

}
