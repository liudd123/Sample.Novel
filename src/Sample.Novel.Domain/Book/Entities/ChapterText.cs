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
    public class ChapterText : Entity<Guid>
    {
        public Chapter Chapter { get; set; }
        public Guid ChapterId { get; set; }
        [MaxLength(ChapterTextConsts.MaxContextLength)]
        public string Context { get; set; }
        [MaxLength(ChapterTextConsts.MaxAuthorMessageLength)]
        public string AuthorMessage { get; set; }

        protected ChapterText()
        {

        }
        public ChapterText([NotNull] string context, [CanBeNull] string authorMessage = null)
        {
            Context = Check.NotNullOrWhiteSpace(context, nameof(context));
            AuthorMessage = authorMessage;
        }
    }
}
