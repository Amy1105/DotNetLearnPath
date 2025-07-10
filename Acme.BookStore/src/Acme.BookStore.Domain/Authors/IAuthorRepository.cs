using Acme.BookStore.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Authors
{
    public interface IAuthorRepository :  IRepository<Author, Guid>
    {
        Task<Author> GetByNameAsync(string name);
        Task<List<Author>> GetListWithMostBooksAsync(int count = 10);
    }
}
