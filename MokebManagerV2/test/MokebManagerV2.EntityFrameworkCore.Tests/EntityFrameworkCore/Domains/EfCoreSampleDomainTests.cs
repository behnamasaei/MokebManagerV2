using MokebManagerV2.Samples;
using Xunit;

namespace MokebManagerV2.EntityFrameworkCore.Domains;

[Collection(MokebManagerV2TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MokebManagerV2EntityFrameworkCoreTestModule>
{

}
