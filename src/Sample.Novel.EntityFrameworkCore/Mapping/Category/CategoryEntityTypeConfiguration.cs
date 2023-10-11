using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Shared.Category;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Category
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Category.Entities.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Category.Entities.Category> builder)
        {
            builder.ToTable(NovelConsts.DbTablePrefix + nameof(Domain.Category.Entities.Category));
            builder.ConfigureByConvention();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(CategoryConsts.MaxNameLength);
        }
    }
}
