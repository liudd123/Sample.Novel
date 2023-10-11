using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Shared.Book;
using Sample.Novel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Book
{
    public class ChapterTextEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Book.Entities.ChapterText>
    {
        public void Configure(EntityTypeBuilder<Domain.Book.Entities.ChapterText> builder)
        {
            builder.ToTable(NovelConsts.DbTablePrefix + nameof(Domain.Book.Entities.ChapterText));
            builder.ConfigureByConvention();
            builder.Property(p => p.Context)
                .IsRequired()
                .HasMaxLength(ChapterTextConsts.MaxContextLength);
            builder.Property(p => p.AuthorMessage).HasMaxLength(ChapterTextConsts.MaxAuthorMessageLength);
        }
    }
}
