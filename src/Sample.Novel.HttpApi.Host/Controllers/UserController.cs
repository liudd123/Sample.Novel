using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    [ControllerName("User(用户)")]
    [Route("api/[controller]/[action]")]
    public class UserController : IIdentityUserAppService
    {
        private readonly IIdentityUserAppService userAppService;

        public UserController(IIdentityUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }
        [HttpPost]
        public async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return await userAppService.CreateAsync(input);
        }

        [HttpGet]
        public async Task DeleteAsync(Guid id)
        {
            await userAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return await userAppService.FindByEmailAsync(email);
        }

        [HttpGet]
        public async Task<IdentityUserDto> FindByUsernameAsync(string userName)
        {
            return await userAppService.FindByUsernameAsync(userName);
        }

        [HttpGet]
        public async Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        {
            return await userAppService.GetAssignableRolesAsync();
        }

        [HttpGet]
        public async Task<IdentityUserDto> GetAsync(Guid id)
        {
            return await userAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return await userAppService.GetListAsync(input);
        }
        [HttpGet]
        public async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return await userAppService.GetRolesAsync(id);
        }

        [HttpPost]
        public async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            return await userAppService.UpdateAsync(id, input);
        }

        [HttpPost]
        public async Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            await userAppService.UpdateRolesAsync(id, input);
        }
    }
}
