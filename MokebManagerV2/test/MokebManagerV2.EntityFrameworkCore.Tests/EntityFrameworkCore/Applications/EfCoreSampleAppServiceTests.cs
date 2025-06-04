using MokebManagerV2.Samples;
using Xunit;

namespace MokebManagerV2.EntityFrameworkCore.Applications;

[Collection(MokebManagerV2TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MokebManagerV2EntityFrameworkCoreTestModule>
{

}
