using AutoMapper;
using BookApi.Dtos.BookDto;
using BookApi.Models;
using Microsoft.AspNetCore.Identity;
namespace BookApi.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Book, GetBookRequestDto>().ReverseMap();
            CreateMap<AddBookRequestDto, Book>().ReverseMap();
            CreateMap<UpdateBookRequestDto, Book>().ReverseMap();
        }
    }
}
