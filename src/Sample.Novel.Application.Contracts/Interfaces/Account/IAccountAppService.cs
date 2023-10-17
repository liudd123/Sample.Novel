using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts.Interfaces.Account
{
    public interface IAccountAppService:IApplicationService
    {
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);
        Task ResetPasswordAsync(ResetPasswordDto input);
    }
}
