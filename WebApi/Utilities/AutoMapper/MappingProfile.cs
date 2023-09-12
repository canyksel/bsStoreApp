using AutoMapper;
using Entities.DTOs;
using Entities.Modals;

namespace WebApi.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookDtoForUpdate, Book>();
        CreateMap<Book, BookDto>();
    }
}
