using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class RoleController : AbpControllerBase, IRoleAppService
    {
        private readonly IRoleAppService roleAppService;

        public RoleController(IRoleAppService roleAppService)
        {
            this.roleAppService = roleAppService;
        }
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateAsync(IdentityRoleCreateDto input)
        {
            await roleAppService.CreateAsync(input);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task DeleteAsync(Guid id)
        {
            await roleAppService.DeleteAsync(id);
        }

        /// <summary>
        /// 获取所有的角色集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            return await roleAppService.GetAllListAsync();
        }

        /// <summary>
        /// 根据id获取角色详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IdentityRoleDto> GetAsync(Guid id)
        {
            return await roleAppService.GetAsync(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<IdentityRoleDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            return await roleAppService.GetListAsnyc(input);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
        {
            return await roleAppService.UpdateAsync(id, input);
        }
    }
}
