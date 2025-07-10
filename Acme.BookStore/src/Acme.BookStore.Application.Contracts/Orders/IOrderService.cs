using Acme.BookStore.OrdersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Orders
{
    public  interface IOrderService:IApplicationService
    {
         Task<OrderDto> GetAsync(Guid id);
         Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input);
        Task<OrderDto> CreateAsync(CreateOrderDto input);
         Task CancelAsync(Guid id);
         Task PayAsync(Guid id, string paymentMethod);
    }
}
