using Sample.Novel.Domain.Shared.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    public class Chapter : Entity<Guid>,IHasCreationTime
    {
        public Volume Volume { get; set; }
        public Guid VolumeId { get; set; }
        [MaxLength(ChapterConsts.MaxTitleLength)]
        public string Title { get; set; }
        public int WordsNumber { get; set; }

        public virtual DateTime CreationTime { get; set; }
        public ChapterText ChapterText { get; set; }
        protected Chapter()
        {
            
        }

        public Chapter( string title, string context,string authorMessage)
        {
            Title = title;
            WordsNumber = context.Length;
            ChapterText=new ChapterText( context, authorMessage);
        }
    }
}
