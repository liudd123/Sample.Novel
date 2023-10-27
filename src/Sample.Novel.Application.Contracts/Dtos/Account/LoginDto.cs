using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Application.Contracts.Dtos.Account
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 校验码
        /// </summary>
        public string CaptchaCode { get; set; }
        public string CaptchaId { get; set; }
    }
}
