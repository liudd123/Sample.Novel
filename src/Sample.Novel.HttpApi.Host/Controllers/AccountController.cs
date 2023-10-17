﻿using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Dtos.Account;
using Sample.Novel.Application.Contracts.Interfaces.Account;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    /// <summary>
    /// Account(账户)
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class AccountController : AbpControllerBase, IAccountAppService
    {
        private readonly IAccountAppService accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            this.accountAppService = accountAppService;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            return await accountAppService.RegisterAsync(input);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task ResetPasswordAsync(ResetPasswordDto input)
        {
            await accountAppService.ResetPasswordAsync(input);
        }
    }
}
