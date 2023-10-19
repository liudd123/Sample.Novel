using Sample.Novel.Domain.Shared.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Sample.Novel.Application.Contracts.Dtos;
public class RegisterDto : ExtensibleObject
{
    [Required]
    [MaxLength(IdentityUserConsts.MaxUserNameLength)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(IdentityUserConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(IdentityUserConsts.MaxEmailLength)]
    public string EmailAddress { get; set; }

    [MaxLength(IdentityUserConsts.MaxPhoneNumberLength)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(IdentityUserConsts.MaxPasswordLength)]
    [DataType(DataType.Password)]
    [DisableAuditing]
    public string Password { get; set; }
}
