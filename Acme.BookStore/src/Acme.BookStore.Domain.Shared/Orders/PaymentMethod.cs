using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Orders
{
    /// <summary>
    /// 支付方式枚举
    /// </summary>
    public enum PaymentMethod
    {
        Unknown = 0,
        CreditCard = 1,
        PayPal = 2,
        Alipay = 3,
        WeChatPay = 4,
        CashOnDelivery = 5
    }
}
