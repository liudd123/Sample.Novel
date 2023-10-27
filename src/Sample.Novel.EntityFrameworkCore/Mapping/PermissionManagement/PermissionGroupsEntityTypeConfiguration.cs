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
    public class PermissionGroupsEntityTypeConfiguration : IEntityTypeConfiguration<PermissionGroupDefinitionRecord>
    {
        public void Configure(EntityTypeBuilder<PermissionGroupDefinitionRecord> builder)
        {
            builder.ToTable("PermissionGroups");

            builder.ConfigureByConvention();

            builder.Property(x => x.Name).HasMaxLength(PermissionGroupDefinitionRecordConsts.MaxNameLength).IsRequired();
            builder.Property(x => x.DisplayName).HasMaxLength(PermissionGroupDefinitionRecordConsts.MaxDisplayNameLength).IsRequired();

            builder.HasIndex(x => new { x.Name }).IsUnique();

            builder.ApplyObjectExtensionMappings();
        }
    }
}
