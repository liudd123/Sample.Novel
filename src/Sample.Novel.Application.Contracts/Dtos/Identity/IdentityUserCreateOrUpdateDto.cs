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

namespace Sample.Novel.Application.Contracts.Dtos.Identity
{
    public class IdentityUserCreateOrUpdateDto : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
        public string UserName { get; set; }

        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxNameLength))]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
        public string Email { get; set; }

        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPhoneNumberLength))]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public bool LockoutEnabled { get; set; }

        [CanBeNull]
        public string[] RoleIds { get; set; }

        protected IdentityUserCreateOrUpdateDto() : base(false)
        {

        }
    }
}
