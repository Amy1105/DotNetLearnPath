using Acme.BookStore.Authors;
using Acme.BookStore.BooksDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Books
{
    public class BookService : ApplicationService, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IObjectMapper _objectMapper;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            IObjectMapper objectMapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _objectMapper = objectMapper;
        }

        public Task<BookDto> CreateAsync(CreateBookDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);
            return _objectMapper.Map<Book, BookDto>(book);
        }

        public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        {
            var books = await _bookRepository.GetListAsync(
                sorting: input.Sorting,
                skipCount: input.SkipCount,
                maxResultCount: input.MaxResultCount
            );

            var totalCount = await _bookRepository.GetCountAsync();

            return new PagedResultDto<BookDto>(
                totalCount,
                _objectMapper.Map<List<Book>, List<BookDto>>(books)
            );
        }

        public Task UpdateAsync(Guid id, UpdateBookDto input)
        {
            throw new NotImplementedException();
        }
    }
}
