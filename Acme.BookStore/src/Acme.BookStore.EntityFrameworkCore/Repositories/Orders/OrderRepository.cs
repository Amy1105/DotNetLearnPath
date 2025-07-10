using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Repositories.Orders
{
    public class OrderRepository : EfCoreRepository<BookStoreDbContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Order>> GetListAsync(bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.Orders;
            return await query.ToListAsync();
        }
    }
}
