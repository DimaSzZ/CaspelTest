using AutoMapper;
using CaspelTest.AutoMapper.dto;
using CaspelTest.Parsistence.Models;

namespace CaspelTest.AutoMapper.Mapper;

public class MapBook : Profile
{
    public MapBook()
    {
        CreateMap<Book, BookModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<BookModel, Book>();
    }
}