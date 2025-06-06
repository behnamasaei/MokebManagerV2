using System.Threading.Tasks;
using MokebManagerV2.Localization;
using MokebManagerV2.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace MokebManagerV2.Web.Menus;

public class MokebManagerV2MenuContributor : IMenuContributor
{
   
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var L = context.GetLocalizer<MokebManagerV2Resource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MokebManagerV2Menus.Home,
                L["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                MokebManagerV2Menus.Mokeb,
                L["Menu:MokebSettings"],
                "~/mokeb",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.Insert(
            2,
            new ApplicationMenuItem(
                MokebManagerV2Menus.PilgrimReception,
                L["Menu:PilgrimReception"],
                "~/pilgrim/new",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
