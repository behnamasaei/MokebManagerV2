using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MokebManagerV2.Pages;

public class Index_Tests : MokebManagerV2WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
