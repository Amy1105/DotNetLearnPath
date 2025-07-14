using Acme.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.IRepository
{
    public interface IBookReviewRepository : IRepository<BookReview, Guid>
    {

    }
}
