using Microsoft.Extensions.Localization;
using MokebManagerV2.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MokebManagerV2.Web;

[Dependency(ReplaceServices = true)]
public class MokebManagerV2BrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<MokebManagerV2Resource> _localizer;

    public MokebManagerV2BrandingProvider(IStringLocalizer<MokebManagerV2Resource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
