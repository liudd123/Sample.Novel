using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Identity;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Shared.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Identity
{
    public class IdentityUserEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {

            builder.ToTable(IdentityDbProperties.DbTablePrefix + "Users");

            builder.ConfigureByConvention();

            builder.Property(u => u.PasswordHash).HasMaxLength(IdentityUserConsts.MaxPasswordHashLength)
                .HasColumnName(nameof(IdentityUser.PasswordHash));

            builder.Property(u => u.LockoutEnabled).HasDefaultValue(false)
                .HasColumnName(nameof(IdentityUser.LockoutEnabled));


            builder.Property(u => u.AccessFailedCount)
                .HasDefaultValue(0)
                .HasColumnName(nameof(IdentityUser.AccessFailedCount));

            builder.HasIndex(u => u.UserName);
            builder.HasIndex(u => u.Email);
            builder.HasMany(u => u.Roles).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            builder.ApplyObjectExtensionMappings();

        }
    }
}
