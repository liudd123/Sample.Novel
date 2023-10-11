using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Shared.Book;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Book
{
    public class VolumeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Book.Entities.Volume>
    {
        public void Configure(EntityTypeBuilder<Domain.Book.Entities.Volume> builder)
        {
            builder.ToTable(NovelConsts.DbTablePrefix + nameof(Domain.Book.Entities.Volume));
            builder.ConfigureByConvention();
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(VolumeConsts.MaxTitleLength);
            builder.Property(p => p.Description).HasMaxLength(VolumeConsts.MaxDescriptionLength);
        }
    }
}
