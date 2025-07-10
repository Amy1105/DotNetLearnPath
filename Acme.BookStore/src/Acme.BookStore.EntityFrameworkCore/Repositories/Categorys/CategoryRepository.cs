using Acme.BookStore.Books;
using Acme.BookStore.Categorys;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Repositories.Categorys
{
    public class CategoryRepository : EfCoreRepository<BookStoreDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Category>> GetListAsync(bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.Categories;
            return await query.ToListAsync();
        }
    }
}
