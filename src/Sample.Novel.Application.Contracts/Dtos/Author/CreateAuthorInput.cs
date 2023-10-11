using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Author
{
    public class CreateAuthorInput:EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
