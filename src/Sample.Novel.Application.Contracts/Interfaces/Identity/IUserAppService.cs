using Sample.Novel.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
 