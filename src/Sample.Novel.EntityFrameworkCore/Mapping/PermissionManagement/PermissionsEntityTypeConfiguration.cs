using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.PermissionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.PermissionManagement
{
    public class PermissionsEntityTypeConfiguration : IEntityTypeConfiguration<PermissionDefinitionRecord>
    {
        public void Configure(EntityTypeBuilder<PermissionDefinitionRecord> builder)
        {
            builder.ToTable("Permissions");

            builder.ConfigureByConvention();

            builder.Property(x => x.GroupName).HasMaxLength(PermissionGroupDefinitionRecordConsts.MaxNameLength).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(PermissionDefinitionRecordConsts.MaxNameLength).IsRequired();
            builder.Property(x => x.ParentName).HasMaxLength(PermissionDefinitionRecordConsts.MaxNameLength);
            builder.Property(x => x.DisplayName).HasMaxLength(PermissionDefinitionRecordConsts.MaxDisplayNameLength).IsRequired();
            builder.Property(x => x.Providers).HasMaxLength(PermissionDefinitionRecordConsts.MaxProvidersLength);
            builder.Property(x => x.StateCheckers).HasMaxLength(PermissionDefinitionRecordConsts.MaxStateCheckersLength);

            builder.HasIndex(x => new { x.Name }).IsUnique();
            builder.HasIndex(x => new { x.GroupName });

            builder.ApplyObjectExtensionMappings();
        }
    }
}
