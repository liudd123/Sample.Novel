using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    [ControllerName("User(用户)")]
    [Route("api/[controller]/[action]")]
    public class UserController : AbpControllerBase, IUserAppService
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
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
