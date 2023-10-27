using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.PermissionManagement;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.PermissionManagement
{
    public class PermissionGrantEntityTypeConfiguration : IEntityTypeConfiguration<PermissionGrant>
    {
        public void Configure(EntityTypeBuilder<PermissionGrant> builder)
        {
            builder.ToTable(nameof(PermissionGrant));
            builder.ConfigureByConvention();
            builder.Property(x => x.Name).HasMaxLength(PermissionDefinitionRecordConsts.MaxNameLength).IsRequired();
            builder.Property(x => x.ProviderName).HasMaxLength(PermissionGrantConsts.MaxProviderNameLength).IsRequired();
            builder.Property(x => x.ProviderKey).HasMaxLength(PermissionGrantConsts.MaxProviderKeyLength).IsRequired();
            builder.HasIndex(x => new { x.Name, x.ProviderName, x.ProviderKey }).IsUnique();
            builder.ApplyObjectExtensionMappings();
        }
    }
}
