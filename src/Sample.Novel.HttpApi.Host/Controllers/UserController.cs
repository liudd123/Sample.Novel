using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController : AbpControllerBase, IUserAppService
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return await userAppService.CreateAsync(input);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task DeleteAsync(Guid id)
        {
            await userAppService.DeleteAsync(id);
        }

        /// <summary>
        /// 根据email获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return await userAppService.FindByEmailAsync(email);
        }
        /// <summary>
        /// 根据userName获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IdentityUserDto> FindByUserNameAsync(string userName)
        {
            return await userAppService.FindByUserNameAsync(userName);
        }
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        {
            return await userAppService.GetAssignableRolesAsync();
        }
        /// <summary>
        /// 根据id获取用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IdentityUserDto> GetAsync(Guid id)
        {
            return await userAppService.GetAsync(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return await userAppService.GetListAsync(input);
        }

        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return await userAppService.GetRolesAsync(id);
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateInput input)
        {
            return await userAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 修改用户的角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            await userAppService.UpdateRolesAsync(id, input);
        }
    }
}
