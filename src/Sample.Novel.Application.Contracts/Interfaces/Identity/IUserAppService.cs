using Sample.Novel.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces
{
    public interface IUserAppService:IApplicationService
    {
        Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);
        Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync();
        Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

        Task<IdentityUserDto> FindByUserNameAsync(string userName);

        Task<IdentityUserDto> FindByEmailAsync(string email);
        Task<IdentityUserDto> CreateAsync(IdentityUserCreateInput input);
        Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateInput input);
        Task DeleteAsync(Guid id);
        Task<IdentityUserDto> GetAsync(Guid id);
    }
}
 