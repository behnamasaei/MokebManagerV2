using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using MokebManagerV2.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace MokebManagerV2;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule)    
    )]
public class MokebManagerV2DomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        MokebManagerV2GlobalFeatureConfigurator.Configure();
        MokebManagerV2ModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MokebManagerV2DomainSharedModule>();
        });


        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<MokebManagerV2Resource>("fa")
                .AddVirtualJson("/Localization/MokebManagerV2")
                .AddBaseTypes(typeof(AbpValidationResource));

            options.Languages.Add(new LanguageInfo("fa", "fa", "فارسی"));
        });

        // ۲. پیکربندی RequestLocalizationOptions با GregorianCalendar
        context.Services.Configure<RequestLocalizationOptions>(opts =>
        {
            // ایجاد یک CultureInfo برای fa-IR
            var fa = new CultureInfo("fa-IR");
            // جایگزینی تقویم پیش‌فرض (PersianCalendar) با GregorianCalendar
            fa.DateTimeFormat.Calendar = new GregorianCalendar();

            // تعیین فرهنگ پیش‌فرض و لیست فرهنگ‌های پشتیبانی‌شده
            opts.DefaultRequestCulture = new RequestCulture(fa);
            opts.SupportedCultures = new List<CultureInfo> { fa };
            opts.SupportedUICultures = new List<CultureInfo> { fa };
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("MokebManagerV2", typeof(MokebManagerV2Resource));
        });


        Configure<AbpLocalizationOptions>(options =>
        {
            options.DefaultResourceType = typeof(MokebManagerV2Resource);
        });


        
    }
}
