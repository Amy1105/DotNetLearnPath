using AutoMapper;
using Acme.BookStore.Dto;
using Acme.BookStore.Models;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CreateBookDto, Book>();

        CreateMap<Category, CategoryDto>();

        CreateMap<Author, AuthorDto>();
    }
}
