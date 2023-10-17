using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class IdentityRoleUpdateDto: IdentityRoleCreateOrUpdateDto, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}
