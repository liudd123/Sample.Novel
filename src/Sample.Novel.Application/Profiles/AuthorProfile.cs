using AutoMapper;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Domain.Author.Entities;

namespace Sample.Novel.Application.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorInput, Author>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
