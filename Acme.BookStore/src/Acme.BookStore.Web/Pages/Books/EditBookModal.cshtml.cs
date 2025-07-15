using Acme.BookStore.Books;
using Acme.BookStore.Dto;
using Acme.BookStore.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Pages.Books
{
    public class EditBookModalModel : BookStorePageModel
    {
        public SelectListItem[] Categories { get; set; }

        public SelectListItem[] Authors { get; set; }


        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateBookViewModel Book { get; set; }


        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;
        private readonly IBookService bookService;
        public EditBookModalModel(IAuthorService _authorService, IBookService _bookService, ICategoryService _categoryService)
        {
            bookService = _bookService;
            categoryService = _categoryService;
            authorService = _authorService;
        }
        public async Task OnGet()
        {
            Book = new CreateBookViewModel
            {
                Status = BookStatus.Draft
            };

            var categoryLookup = await categoryService.GetListAsync();
            Categories = categoryLookup.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();

            var authorLookup = await authorService.GetListAsync();
            Authors = authorLookup.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();

            var bookDto = await bookService.GetAsync(Id);          
            Book = ObjectMapper.Map<BookDto, CreateBookViewModel>(bookDto);           
        }
    }    
}
