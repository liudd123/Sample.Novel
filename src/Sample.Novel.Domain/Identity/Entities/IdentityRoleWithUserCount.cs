using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Domain.Identity.Entities
{
    public class IdentityRoleWithUserCount
    {
        public IdentityRole Role { get; set; }

        public long UserCount { get; set; }

        public IdentityRoleWithUserCount(IdentityRole role, long userCount)
        {
            Role = role;
            UserCount = userCount;
        }
    }
}
