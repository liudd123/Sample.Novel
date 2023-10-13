using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class IdentityRoleWithUserCountDot
    {
        public IdentityRoleDto Role { get; set; }

        public long UserCount { get; set; }

        public IdentityRoleWithUserCountDot(IdentityRoleDto role, long userCount)
        {
            Role = role;
            UserCount = userCount;
        }
    }
}
