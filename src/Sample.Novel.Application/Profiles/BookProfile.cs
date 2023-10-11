using AutoMapper;
using Sample.Novel.Application.Contracts.Dtos.Book;
using Sample.Novel.Domain.Book.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookInput, Book>();
            CreateMap<Book, BookDto>();

            CreateMap<CreateVolumeInput, Volume>();
            CreateMap<Volume, VolumeDto>();

            CreateMap<CreateChapterInput, Chapter>();
            CreateMap<Chapter, ChapterDto>();

            CreateMap<CreateChapterTextInput, ChapterText>();
            CreateMap<ChapterText, ChapterTextDto>();

        }
    }
}
