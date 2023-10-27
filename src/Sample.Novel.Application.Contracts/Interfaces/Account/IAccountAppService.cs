using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Dtos.Account;
using Sample.Novel.Domain.Shared.Result;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);
        Task ResetPasswordAsync(ResetPasswordDto input);
        Task<ApiResponse> LoginAsync(LoginDto input);
        IActionResult Captcha(string id);
        
    }
}
