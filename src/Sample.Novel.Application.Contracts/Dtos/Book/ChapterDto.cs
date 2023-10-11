using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    public class ChapterDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int WordsNumber { get; set; }
        public ChapterTextDto ChapterText { get; set; }
    }
}
