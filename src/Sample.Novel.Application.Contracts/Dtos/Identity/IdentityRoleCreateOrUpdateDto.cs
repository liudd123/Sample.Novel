using Sample.Novel.Domain.Shared.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class IdentityRoleCreateOrUpdateDto : ExtensibleObject
    {
        [Required]
        [MaxLength(IdentityRoleConsts.MaxNameLength)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        protected IdentityRoleCreateOrUpdateDto() : base(false)
        {

        }
    }
}
