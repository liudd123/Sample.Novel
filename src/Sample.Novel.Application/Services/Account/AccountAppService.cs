using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Dtos.Account;
using Sample.Novel.Application.Contracts.Interfaces.Account;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Identity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectExtending;

namespace Sample.Novel.Application.Services.Account
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly IIdentityUserRepository userRepository;
        private readonly IIdentityRoleRepository roleRepository;

        public AccountAppService(IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }
        public virtual async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {

            var user = new IdentityUser(GuidGenerator.Create(), input.UserName, input.EmailAddress);

            user.SetPasswordHash(EncryptHelper.ToMD5(input.Password));
            input.MapExtraPropertiesTo(user);

            //添加默认角色
            await AddDefaultRolesAsync(user.Id);

            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }

        public async Task ResetPasswordAsync(ResetPasswordDto input)
        {
            var user = await userRepository.GetAsync(input.UserId);
            user.SetPasswordHash(EncryptHelper.ToMD5(input.Password));
            await userRepository.UpdateAsync(user);
        }
        protected async Task AddDefaultRolesAsync(Guid userId)
        {
            var roles = await roleRepository.GetDefaultRolesAsync();
            var userRoles = roles.Select(s => new IdentityUserRole(userId, s.Id));
            await userRepository.AddRolesAsync(userRoles);
        }
    }
}
