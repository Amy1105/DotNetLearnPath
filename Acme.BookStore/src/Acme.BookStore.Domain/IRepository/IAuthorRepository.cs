using Acme.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.IRepository
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
        Task<List<Author>> GetListAsync(bool includeCategory = false);
    }
}
