using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.IRepository;
using Acme.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Repositories
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
