using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Shared.Author;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mapping.Author
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Author.Entities.Author>
    {
        public void Configure(EntityTypeBuilder<Domain.Author.Entities.Author> builder)
        {
            builder.ToTable(NovelConsts.DbTablePrefix + nameof(Domain.Author.Entities.Author));
            builder.ConfigureByConvention();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(AuthorConsts.MaxNameLength);
            builder.Property(p => p.Description)
                .HasMaxLength(AuthorConsts.MaxDescriptionLength);
        }
    }
}
