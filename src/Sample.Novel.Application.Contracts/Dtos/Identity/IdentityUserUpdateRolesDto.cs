﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Application.Contracts.Dtos.Identity
{
    public class IdentityUserUpdateRolesDto
    {
        public List<Guid> RoleIds { get; set; }
    }
}
