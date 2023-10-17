using Microsoft.AspNetCore.Authorization;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Identity.Repository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Users;

namespace Sample.Novel.Application.Services
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IIdentityUserRepository userRepository;
        private readonly IIdentityRoleRepository roleRepository;

        public UserAppService(IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public virtual async Task<IdentityUserDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(
                await userRepository.GetAsync(id)
            );
        }

        public virtual async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            var count = await userRepository.GetCountAsync(input.Filter);
            var list = await userRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<IdentityUserDto>(
                count,
                ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(list)
            );
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            //TODO: Should also include roles of the related OUs.

            var roles = await userRepository.GetRolesAsync(id);

            return new ListResultDto<IdentityRoleDto>(
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(roles)
            );
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        {
            var list = await roleRepository.GetListAsync();
            return new ListResultDto<IdentityRoleDto>(
                ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list));
        }

        public virtual async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            var user = new IdentityUser(GuidGenerator.Create(), input.UserName, input.Email);
            //赋值扩展属性
            input.MapExtraPropertiesTo(user);
            Check.NotNullOrWhiteSpace(input.Password, "密码");
            user.SetPasswordHash(EncryptHelper.ToMD5(input.Password));
            await UpdateUserByInput(user, input);
            user = await userRepository.InsertAsync(user);
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }

        public virtual async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateInput input)
        {
            var user = await userRepository.GetAsync(id);
            user.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

            if (!input.Password.IsNullOrWhiteSpace())
            {
                user.SetPasswordHash(EncryptHelper.ToMD5(input.Password));
            }
            await UpdateUserByInput(user, input);
            input.MapExtraPropertiesTo(user);
            user = await userRepository.UpdateAsync(user);
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            if (CurrentUser.Id == id)
            {
                throw new Exception("不可以删除当前登录用户");
            }

            await userRepository.DeleteAsync(id);
        }

        public virtual async Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            var user = await userRepository.GetAsync(id);
            foreach (var roleId in input.RoleIds)
            {
                user.AddRole(roleId);
            }

            await userRepository.UpdateAsync(user);
        }

        public virtual async Task<IdentityUserDto> FindByUserNameAsync(string userName)
        {
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(
                await userRepository.FindByUserNameAsync(userName)
            );
        }

        public virtual async Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(
                await userRepository.FindByEmailAsync(email)
            );
        }

        protected virtual async Task UpdateUserByInput(IdentityUser user, IdentityUserCreateOrUpdateDto input)
        {
            if (!string.Equals(user.Email, input.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                user.SetEmail(input.Email, false);
            }

            if (!string.Equals(user.PhoneNumber, input.PhoneNumber, StringComparison.InvariantCultureIgnoreCase))
            {
                user.SetPhoneNumber(input.PhoneNumber, false);
            }
            user.SetLockoutEnabled(input.LockoutEnabled);
            user.Name = input.Name;
            user.SetIsActive(input.IsActive);
            if (input.RoleIds != null)
            {
                await userRepository.RemoveRoles(user.Id, input.RoleIds.ToList());
                var userRoles = input.RoleIds.Select(s => new IdentityUserRole(user.Id,s)).ToList();
                await userRepository.AddRolesAsync(userRoles);
            }
        }
    }
}
