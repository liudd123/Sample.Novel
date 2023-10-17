using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class IdentityUserDto : ExtensibleFullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool IsActive { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public DateTimeOffset? LastPasswordChangeTime { get; set; }
        public string ConcurrencyStamp { get; set; }

    }
}
