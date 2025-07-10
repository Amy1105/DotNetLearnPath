using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Repositories.Books
{
    public class BookReviewRepository : EfCoreRepository<BookStoreDbContext, BookReview, Guid>, IBookReviewRepository
    {
        public BookReviewRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BookReview>> GetListAsync(bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.BookReviews;
            return await query.ToListAsync();
        }
    }
}
