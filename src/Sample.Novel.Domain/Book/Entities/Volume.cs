using JetBrains.Annotations;
using Sample.Novel.Domain.Shared.Book;
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
    public class Volume : Entity<Guid>, IHasCreationTime
    {
        public Book Book { get; set; }
        public Guid BookId { get; set; }
        [MaxLength(VolumeConsts.MaxTitleLength)]
        public string Title { get; set; }
        [MaxLength(VolumeConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }
        public List<Chapter> Chapters { get; set; }
        protected Volume()
        {

        }

        public Volume(Guid bookId, [NotNull] string title, [CanBeNull] string description)
        {
            BookId = bookId;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Description = description;
            Chapters = new List<Chapter>();
        }
        public void AddChapter(Chapter chapter)
        {
            if (Chapters.Any(a => a.Title == chapter.Title)) return; Chapters.Add(chapter);
        }
    }
}
