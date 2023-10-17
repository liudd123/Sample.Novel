﻿using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos
{
    public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
