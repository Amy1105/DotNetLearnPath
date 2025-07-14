using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.IRepository;
using Acme.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Repositories
{
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<bool> CreateAsync(Book entity)
        {
           var dbContext = await GetDbContextAsync();
           var IsExists= dbContext.Books.Any(x=>x.Title==entity.Title && x.AuthorId==entity.AuthorId && x.CategoryId==entity.CategoryId);
            if (IsExists)
            {
                return false;
            }
            await dbContext.Books.AddAsync(entity);
            return true;
        }

        public async Task<Book?> GetAsync(Expression<Func<Book, bool>> predicate)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Books.FirstOrDefaultAsync(predicate, cancellationToken: default);
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
