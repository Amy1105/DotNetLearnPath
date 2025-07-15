using Acme.BookStore.Dto;
using Acme.BookStore.Web.Pages.Books;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<CreateBookViewModel, CreateBookDto>();
    }
}
