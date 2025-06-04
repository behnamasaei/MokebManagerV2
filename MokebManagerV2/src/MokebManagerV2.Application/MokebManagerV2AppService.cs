using System;
using System.Collections.Generic;
using System.Text;
using MokebManagerV2.Localization;
using Volo.Abp.Application.Services;

namespace MokebManagerV2;

/* Inherit your application services from this class.
 */
public abstract class MokebManagerV2AppService : ApplicationService
{
    protected MokebManagerV2AppService()
    {
        LocalizationResource = typeof(MokebManagerV2Resource);
    }
}
