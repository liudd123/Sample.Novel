using Sample.Novel.Domain.Shared.Identity;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class IdentityUserUpdateInput: IdentityUserCreateOrUpdateInput, IHasConcurrencyStamp
    {
        [DisableAuditing]
        [MaxLength(IdentityUserConsts.MaxPasswordLength)]
        public string Password { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
