using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Repositories.Books
{
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Book?> GetAsync(Expression<Func<Book,bool>> predicate)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Books.FirstOrDefaultAsync(predicate, cancellationToken:default);
        }

        public Task<Book> GetAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetListByCategoryAsync(Guid categoryId, int skipCount = 0, int maxResultCount = int.MaxValue)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Books
                .Where(b => b.CategoryId == categoryId)
                .OrderByDescending(b => b.CreationTime)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public Task<List<Book>> GetPopularBooksAsync(int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
