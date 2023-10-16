using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Identity;
using Sample.Novel.Domain.Identity.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Identity
{
    public class IdentityUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole> builder)
        {
            builder.ToTable(IdentityDbProperties.DbTablePrefix + "UserRoles");

            builder.ConfigureByConvention();

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne<IdentityRole>().WithMany().HasForeignKey(ur => ur.RoleId).IsRequired();
            builder.HasOne<IdentityUser>().WithMany(u => u.Roles).HasForeignKey(ur => ur.UserId).IsRequired();

            builder.HasIndex(ur => new { ur.RoleId, ur.UserId });

            builder.ApplyObjectExtensionMappings();
        }
    }
}
