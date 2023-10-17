using AutoMapper;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Application.Profiles
{
    public class IdentityRoleProfile : Profile
    {
        public IdentityRoleProfile()
        {
            CreateMap<IdentityRoleCreateDto, IdentityRole>();
            CreateMap<IdentityRoleUpdateDto, IdentityRole>();
            CreateMap<IdentityRole, IdentityRoleDto>();
        }
    }
}
