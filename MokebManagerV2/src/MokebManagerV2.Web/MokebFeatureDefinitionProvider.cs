using MokebManagerV2.Features;
using MokebManagerV2.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace MokebManagerV2.Web
{
    public class MokebFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {

            var myGroup = context.AddGroup(MokebFeatures.SettingsFeatures, LocalizableString
                                 .Create<MokebManagerV2Resource>("MokebSettings"));

            myGroup.AddFeature(
                MokebFeatures.BedStatusFeature,
                defaultValue: "false",
                displayName: LocalizableString
                                 .Create<MokebManagerV2Resource>("BedStatusFeature"),
                valueType: new ToggleStringValueType()
            );

            //myGroup.AddFeature(
            //    "MyApp.MaxProductCount",
            //    defaultValue: "10",
            //    displayName: LocalizableString
            //                     .Create<MokebManagerV2Resource>("MaxProductCount"),
            //    valueType: new FreeTextStringValueType(
            //                   new NumericValueValidator(0, 1000000))
            //);
        }
    }
}
