using Acme.BookStore.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Orders
{
    public interface IOrderItemRepository : IRepository<OrderItem, Guid>
    {

    }
}
