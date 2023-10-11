using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Shared.Book;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Book
{
    public class ChapterEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Book.Entities.Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable(NovelConsts.DbTablePrefix + nameof(Chapter));
            builder.ConfigureByConvention();
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(ChapterConsts.MaxTitleLength);
            builder.HasOne(chapter => chapter.ChapterText).WithOne(text => text.Chapter).HasForeignKey<ChapterText>(text => text.Id);
        }
    }
}
