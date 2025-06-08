using Microsoft.EntityFrameworkCore;
using MokebManagerV2.Models;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace MokebManagerV2.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MokebManagerV2DbContext :
    AbpDbContext<MokebManagerV2DbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region Entities from the models

    public DbSet<Mokeb> Mokebs { get; set; }
    public DbSet<Pilgrim> Pilgrims { get; set; }
    public DbSet<Bed> Beds { get; set; }

    #endregion

    public MokebManagerV2DbContext(DbContextOptions<MokebManagerV2DbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Mokeb>(b =>
        {
            b.ToTable(MokebManagerV2Consts.DbTablePrefix + "Mokeb", MokebManagerV2Consts.DbSchema);
            b.HasMany(x => x.Pilgrims).WithOne(x => x.Mokeb)
                .HasForeignKey(x => x.MokebId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(x => x.Beds).WithOne(x => x.Mokeb)
                .HasForeignKey(x => x.MokebId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasIndex(x => x.Name).IsUnique().HasFilter("[IsDeleted] = 0");
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Pilgrim>(b =>
        {
            b.ToTable(MokebManagerV2Consts.DbTablePrefix + "Pilgrim", MokebManagerV2Consts.DbSchema);
            b.HasOne(x => x.Mokeb).WithMany(x => x.Pilgrims)
                .HasForeignKey(x => x.MokebId);

            b.HasOne(x => x.Bed).WithOne(x => x.Pilgrim)
                .HasForeignKey<Bed>(x => x.PilgrimId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasIndex(x => x.PassportNo).IsUnique();
            b.HasIndex(x => x.NationalCode).IsUnique();
            b.HasIndex(x => x.PhoneNumber).IsUnique();
            b.ConfigureByConvention();
        });

        builder.Entity<Bed>(b =>
        {
            b.ToTable(MokebManagerV2Consts.DbTablePrefix + "Bed", MokebManagerV2Consts.DbSchema);
            b.HasOne(x => x.Pilgrim).WithOne(x => x.Bed)
                .HasForeignKey<Bed>(x => x.PilgrimId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Mokeb).WithMany(x => x.Beds)
                .HasForeignKey(x => x.MokebId)
                .OnDelete(DeleteBehavior.Restrict);

            b.ConfigureByConvention();
        });
    }
}
