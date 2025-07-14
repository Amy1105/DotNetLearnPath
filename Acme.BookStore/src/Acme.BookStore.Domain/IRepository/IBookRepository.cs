using Acme.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.IRepository
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        Task<Book> GetAsync(string isbn);
        Task<List<Book>> GetListByCategoryAsync(Guid categoryId, int skipCount = 0, int maxResultCount = int.MaxValue);
        Task<List<Book>> GetPopularBooksAsync(int count = 10);



        Task<bool> CreateAsync(Book entity);
    }
}
