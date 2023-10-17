using JetBrains.Annotations;
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
    public class IdentityUserCreateOrUpdateDto : ExtensibleObject
    {
        [Required]
        [MaxLength(IdentityUserConsts.MaxUserNameLength)]
        public string UserName { get; set; }

        [MaxLength(IdentityUserConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(IdentityUserConsts.MaxEmailLength)]
        public string Email { get; set; }

        [MaxLength(IdentityUserConsts.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public bool LockoutEnabled { get; set; }

        [CanBeNull]
        public Guid[] RoleIds { get; set; }

        protected IdentityUserCreateOrUpdateDto() : base(false)
        {

        }
    }
}
