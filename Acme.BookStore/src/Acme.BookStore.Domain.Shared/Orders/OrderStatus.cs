using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Orders
{
    /// <summary>
    /// 订单状态枚举
    /// </summary>
    public enum OrderStatus
    {
        PendingPayment = 0,  // 待支付
        Paid = 1,            // 已支付
        Shipped = 2,         // 已发货
        Completed = 3,       // 已完成
        Canceled = 4         // 已取消
    }
}
