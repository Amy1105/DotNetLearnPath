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
    public class AuthorRepository : EfCoreRepository<BookStoreDbContext, Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Author>> GetListAsync(bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.Authors;
            return await query.ToListAsync();
        }
    }
}
