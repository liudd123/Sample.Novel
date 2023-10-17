using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;

namespace Sample.Novel.Application.Contracts.Dtos.Account
{
    public class ResetPasswordDto
    {
        public Guid UserId { get; set; }

        [Required]
        [DisableAuditing]
        public string Password { get; set; }
    }
}
