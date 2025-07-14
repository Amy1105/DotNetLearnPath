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

namespace Acme.BookStore.Repositories.Authors
{
    public class AuthorRepository: EfCoreRepository<BookStoreDbContext, Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Author> GetByNameAsync(string name)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Authors.Where(x => x.Name.Contains(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Author>> GetListAsync(bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.Authors;
            return await query.ToListAsync();
        }

        public Task<List<Author>> GetListWithMostBooksAsync(int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
