using MokebManagerV2.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MokebManagerV2.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MokebManagerV2PageModel : AbpPageModel
{
    protected MokebManagerV2PageModel()
    {
        LocalizationResourceType = typeof(MokebManagerV2Resource);
    }
}
