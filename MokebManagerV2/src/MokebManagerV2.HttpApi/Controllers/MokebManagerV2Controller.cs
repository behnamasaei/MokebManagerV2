using MokebManagerV2.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MokebManagerV2.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MokebManagerV2Controller : AbpControllerBase
{
    protected MokebManagerV2Controller()
    {
        LocalizationResource = typeof(MokebManagerV2Resource);
    }
}
