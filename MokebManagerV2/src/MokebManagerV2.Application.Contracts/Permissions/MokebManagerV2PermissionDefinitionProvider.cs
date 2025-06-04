using MokebManagerV2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MokebManagerV2.Permissions;

public class MokebManagerV2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MokebManagerV2Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MokebManagerV2Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MokebManagerV2Resource>(name);
    }
}
