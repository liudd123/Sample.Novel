using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class ChapterTextDto : EntityDto<Guid>
    {
        public string Context { get; set; }
        public string AuthorMessage { get; set; }
    }
}
