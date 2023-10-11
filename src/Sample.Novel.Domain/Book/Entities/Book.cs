using JetBrains.Annotations;
using Sample.Novel.Domain.Shared.Author;
using Sample.Novel.Domain.Shared.Book;
using Sample.Novel.Domain.Shared.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    public class Book : Entity<Guid>, IHasCreationTime
    {
        [MaxLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }
        [MaxLength(BookConsts.MaxDescriptionLength)]
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        [MaxLength(AuthorConsts.MaxNameLength)]
        public string AuthorName { get; set; }
        public Guid CategoryId { get; set; }
        [MaxLength(CategoryConsts.MaxNameLength)]
        public string CategoryName { get; set; }
        public List<Volume> Volumes { get; protected set; }
        public virtual DateTime CreationTime { get; set; }
        protected Book()
        {

        }

        public Book([NotNull] string name, [NotNull] string description, Guid authorId, [NotNull] string authorName, Guid categoryId, [NotNull] string categoryName)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
            AuthorId = authorId;
            AuthorName = Check.NotNullOrWhiteSpace(authorName, nameof(authorName));
            CategoryId = categoryId;
            CategoryName = Check.NotNullOrWhiteSpace(categoryName, nameof(categoryName));
            Volumes = new List<Volume>();
        }
        public void AddVolume(Volume volume)
        {
            if (Volumes.Any(a => a.Title == volume.Title))
            {
                return;
            }
            Volumes.Add(volume);
        }
    }
}
