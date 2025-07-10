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
    public class OrderItemRepository : EfCoreRepository<BookStoreDbContext, OrderItem, Guid>, IOrderItemRepository
    {
        public OrderItemRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<OrderItem>> GetListAsync(bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.OrderItems;
            return await query.ToListAsync();
        }
    }
}
