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
    public class IdentityRoleCreateOrUpdateInput : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(IdentityRoleConsts), nameof(IdentityRoleConsts.MaxNameLength))]
        [Display(Name = "RoleName")]
        public string Name { get; set; }

        protected IdentityRoleCreateOrUpdateInput() : base(false)
        {

        }
    }
}
