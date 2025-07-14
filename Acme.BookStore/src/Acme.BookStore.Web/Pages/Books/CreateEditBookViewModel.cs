using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Acme.BookStore.Books;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateEditBookViewModel
    {
        [SelectItems("Categories")]
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }

        [SelectItems("Authors")]
        [DisplayName("Author")]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(BookConsts.TitleMaxLength)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public BookStatus Status { get; set; }

        public string ISBN { get; set; }
        public int Stock { get; set; }

        public string CoverImageUrl { get; set; }

        public string Description { get; set; }


    }
}
