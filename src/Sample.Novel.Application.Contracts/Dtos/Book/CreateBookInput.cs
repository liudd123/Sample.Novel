using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Book
{
    public class CreateBookInput:EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
