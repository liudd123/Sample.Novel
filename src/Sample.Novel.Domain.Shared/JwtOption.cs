using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Domain.Shared
{
    public class JwtOption
    {
        public const string JWT = "JWT";
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string IssuerSigningKey { get; set; }
        /// <summary>
        /// 分钟
        /// </summary>
        public int Expires { get; set; }

    }
}
