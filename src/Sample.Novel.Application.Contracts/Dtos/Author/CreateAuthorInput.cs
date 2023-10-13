using Sample.Novel.Domain.Shared.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Author
{
    public class CreateAuthorInput:EntityDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(AuthorConsts.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(AuthorConsts.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
