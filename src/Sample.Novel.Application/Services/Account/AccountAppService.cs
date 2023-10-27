using Lazy.Captcha.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Dtos.Account;
using Sample.Novel.Application.Contracts.Interfaces.Account;
using Sample.Novel.Domain.Identity.Entities;
using Sample.Novel.Domain.Identity.Repository;
using Sample.Novel.Domain.Shared;
using Sample.Novel.Domain.Shared.Result;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Security.Claims;

namespace Sample.Novel.Application.Services.Account
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly IIdentityUserRepository userRepository;
        private readonly IIdentityRoleRepository roleRepository;
        private readonly ICaptcha _captcha;
        private readonly JwtOption _jwtOption;
        public AccountAppService(IIdentityUserRepository userRepository, IIdentityRoleRepository roleRepository, ICaptcha captcha, IOptions<JwtOption> options)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this._captcha = captcha;
            this._jwtOption = options.Value;
        }

        public virtual IActionResult Captcha(string id)
        {
            var info = _captcha.Generate(id);
            // 有多处验证码且过期时间不一样，可传第二个参数覆盖默认配置。
            //var info = _captcha.Generate(id,120);
            var stream = new MemoryStream(info.Bytes);
            return new FileStreamResult(stream, "image/gif");
        }

        public async Task<ApiResponse> LoginAsync(LoginDto input)
        {
            if (!_captcha.Validate(input.CaptchaId, input.CaptchaCode))
            {
                return ApiResponse.Error("验证码错误");
            }
            var user = await userRepository.LoginAsync(input.UserName, EncryptHelper.ToMD5(input.Password));
            if (user == null)
            {
                return ApiResponse.Error("用户名或密码错误！");
            }
            //生成token
            var token = await GenerateToken(user);

            return ApiResponse.OK(token);
        }

        public virtual async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {

            var user = new IdentityUser(GuidGenerator.Create(), input.UserName, input.EmailAddress);

            user.SetPasswordHash(EncryptHelper.ToMD5(input.Password));
            input.MapExtraPropertiesTo(user);

            //添加默认角色
            await AddDefaultRolesAsync(user.Id);
            user.SetPhoneNumber(input.PhoneNumber, false);
            user.SetName(input.Name);

            await userRepository.InsertAsync(user);
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

        private async Task<string> GenerateToken(IdentityUser user)
        {
            var roles = await userRepository.GetRoleNamesAsync(user.Id);
            var roleClaims = roles.Select(s => new Claim(AbpClaimTypes.Role, s)).Distinct();
            //生成token
            var claims = new[] {
                    new Claim(AbpClaimTypes.UserId, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };
            claims = claims.Concat(roleClaims).ToArray();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.IssuerSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: _jwtOption.ValidIssuer,
                audience: _jwtOption.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_jwtOption.Expires)),
                signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
