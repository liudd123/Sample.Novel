using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Identity.Repository;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.ObjectMapping;

namespace Sample.Novel.Application.Services
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleAppService : ApplicationService, IRoleAppService
    {
        private readonly IIdentityRoleRepository roleRepository;

        public RoleAppService(IIdentityRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateAsync(IdentityRoleCreateDto input)
        {
            var role = ObjectMapper.Map<IdentityRoleCreateDto, IdentityRole>(input);
           
            await roleRepository.InsertAsync(role);
        }

        public async Task DeleteAsync(Guid id)
        {
            await roleRepository.DeleteAsync(id);
        }

        public async Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            var list = await roleRepository.GetListAsync();
            return new ListResultDto<IdentityRoleDto>(ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list));
        }

        /// <summary>
        /// 通过id获取角色详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IdentityRoleDto> GetAsync(Guid id)
        {
            var role = await roleRepository.GetAsync(id);
            return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(role);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<IdentityRoleDto>> GetListAsnyc(PagedAndSortedResultRequestDto input)
        {
            var queryable = await roleRepository.GetQueryableAsync();
            queryable.Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(IdentityRole.CreationTime));
            List<IdentityRole> roles = await AsyncExecuter.ToListAsync(queryable);
            var count = await roleRepository.GetCountAsync();
            var roleDtos = ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(roles);
            return new PagedResultDto<IdentityRoleDto>(count, roleDtos);
        }

        public async Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
        {
            var role = await roleRepository.GetAsync(id);
            role.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);
            role.ChangeName(input.Name);
            role = await roleRepository.UpdateAsync(role);
            return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(role);
        }
    }
}
