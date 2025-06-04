using Volo.Abp.Settings;

namespace MokebManagerV2.Settings;

public class MokebManagerV2SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MokebManagerV2Settings.MySetting1));
    }
}
