using MokebManagerV2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using static MokebManagerV2.Permissions.MokebManagerV2Permissions;

namespace MokebManagerV2.Permissions;

public class MokebManagerV2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MokebManagerV2Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MokebManagerV2Permissions.MyPermission1, L("Permission:MyPermission1"));

        #region Mokeb_Permissions

        var mokebGroup = context.AddGroup(MokebsPermissions.Default, L("Permission:MokebManagement"));

        var mokebManagement = mokebGroup.AddPermission(
            MokebsPermissions.Default,
            L("Permission:MokebManagement"),
            multiTenancySide: MultiTenancySides.Tenant);

        mokebManagement.AddChild(
            MokebsPermissions.Create,
            L("Permission:MokebManagementCreate"),
            multiTenancySide: MultiTenancySides.Tenant);

        mokebManagement.AddChild(
            MokebsPermissions.Edit,
            L("Permission:MokebManagementEdit"),
            multiTenancySide: MultiTenancySides.Tenant);
        
        mokebManagement.AddChild(
            MokebsPermissions.Delete,
            L("Permission:MokebManagementDelete"),
            multiTenancySide: MultiTenancySides.Tenant);

        #endregion

        #region Pilgrim_permissions

        var pilgrimGroup = context.AddGroup(PilgrimsPermissions.Default, L("Permission:PilgrimManagement"));

        var pilgrimManagement = pilgrimGroup.AddPermission(
            PilgrimsPermissions.Default,
            L("Permission:PilgrimManagement"),
            multiTenancySide: MultiTenancySides.Tenant);

        pilgrimManagement.AddChild(
            PilgrimsPermissions.Create,
            L("Permission:PilgrimManagementCreate"),
            multiTenancySide: MultiTenancySides.Tenant);

        pilgrimManagement.AddChild(
            PilgrimsPermissions.Edit,
            L("Permission:PilgrimManagementEdit"),
            multiTenancySide: MultiTenancySides.Tenant);

        pilgrimManagement.AddChild(
            PilgrimsPermissions.Delete,
            L("Permission:PilgrimManagementDelete"),
            multiTenancySide: MultiTenancySides.Tenant);


        #endregion
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MokebManagerV2Resource>(name);
    }
}
