using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.BooksDto
{
    public class BookDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
        public BookStatus Status { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreationTime { get; set; }
    }
    public class GetBookListDto
    {
        public string Sorting { get; set; }
        public int    SkipCount { get; set; }
        public int   MaxResultCount { get; set; }
    }

    public class CreateBookDto
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        [Required]
        [Range(0, 9999)]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public int Stock { get; set; } = 0;

        public BookStatus Status { get; set; } = BookStatus.Draft;

        public string CoverImageUrl { get; set; }
    }

    public class UpdateBookDto
    {

    }
}
