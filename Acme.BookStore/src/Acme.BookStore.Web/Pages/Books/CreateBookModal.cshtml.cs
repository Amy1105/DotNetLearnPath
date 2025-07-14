using Acme.BookStore.Books;
using Acme.BookStore.Dto;
using Acme.BookStore.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateBookModalModel : BookStorePageModel
    {
        public SelectListItem[] Categories { get; set; }

        public SelectListItem[] Authors { get; set; }

        [BindProperty]
        public CreateEditBookViewModel Book { get; set; }

        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;
        private readonly IBookService bookService;
        public CreateBookModalModel(IAuthorService _authorService,IBookService _bookService, ICategoryService _categoryService)
        {
            bookService = _bookService;
            categoryService= _categoryService;
            authorService = _authorService;
        }

        /// <summary>
        /// 页面打开时，
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            Book = new CreateEditBookViewModel
            {           
                Status = BookStatus.Draft
            };

            var categoryLookup = await categoryService.GetListAsync();
            Categories = categoryLookup.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();

            var authorLookup = await authorService.GetListAsync();
            Authors = authorLookup.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var productDto = ObjectMapper.Map<CreateEditBookViewModel, CreateBookDto>(Book);
            var result = await bookService.CreateAsync(productDto);
           if(!result)
            {
                return Content(L["BOOKExists"]);
            }
            return Content(L["AddSuccesss"]);
        }
    }
}
