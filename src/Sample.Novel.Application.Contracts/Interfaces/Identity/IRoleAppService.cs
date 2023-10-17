using Sample.Novel.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IRoleAppService : IApplicationService
    {
        Task CreateAsync(IdentityRoleCreateDto input);
        Task<IdentityRoleDto> GetAsync(Guid id);
        Task<PagedResultDto<IdentityRoleDto>> GetListAsnyc(PagedAndSortedResultRequestDto input);
        Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();
        Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input);
        Task DeleteAsync(Guid id);
    }
}
