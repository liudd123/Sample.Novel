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
using Sample.Novel.Domain.Shared.Author;
using Sample.Novel.Domain.Shared.Category;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Book
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Book.Entities.Book>
    {
        public void Configure(EntityTypeBuilder<Domain.Book.Entities.Book> builder)
        {
            builder.ToTable(NovelConsts.DbTablePrefix + nameof(Domain.Book.Entities.Book));
            builder.ConfigureByConvention();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(BookConsts.MaxNameLength);
            builder.Property(p => p.Description).HasMaxLength(BookConsts.MaxDescriptionLength);
            builder.Property(p => p.AuthorName).HasMaxLength(AuthorConsts.MaxNameLength);
            builder.Property(p => p.CategoryName).HasMaxLength(CategoryConsts.MaxNameLength);
        }
    }
}
