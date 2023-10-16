using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    public class IdentityRoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.ToTable(IdentityDbProperties.DbTablePrefix + "Roles");

            builder.ConfigureByConvention();

            builder.Property(r => r.Name).IsRequired().HasMaxLength(IdentityRoleConsts.MaxNameLength);
            builder.Property(r => r.IsStatic).HasColumnName(nameof(IdentityRole.IsStatic));

            builder.ApplyObjectExtensionMappings();
        }
    }
}
