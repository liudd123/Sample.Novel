using AutoMapper;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Domain.Category.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryInput, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
