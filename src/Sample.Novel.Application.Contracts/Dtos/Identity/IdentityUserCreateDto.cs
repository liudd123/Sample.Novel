using Sample.Novel.Domain.Shared.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Validation;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class IdentityUserCreateDto: IdentityUserCreateOrUpdateDto
    {
        [DisableAuditing]
        [Required]
        [MaxLength(IdentityUserConsts.MaxPasswordLength)]
        public string Password { get; set; }

    }
}
