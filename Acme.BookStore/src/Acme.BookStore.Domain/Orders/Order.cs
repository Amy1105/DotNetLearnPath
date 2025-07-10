using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Guids;
using Volo.Abp;

namespace Acme.BookStore.Orders
{
    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public PaymentMethod PaymentMethod { get; private set; }

        /// <summary>
        /// 支付交易ID（如果已支付）
        /// </summary>
        public string PaymentTransactionId { get; private set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string ShippingAddress { get; private set; }

        /// <summary>
        /// 订单明细集合
        /// </summary>
        public virtual ICollection<OrderItem> Items { get; private set; }

        //private Order() { }

        //public static Order Create(
        //    Guid id,
        //    string orderNumber,
        //    Guid userId,
        //    string shippingAddress,
        //    PaymentMethod paymentMethod)
        //{
        //    Check.NotNullOrWhiteSpace(orderNumber, nameof(orderNumber));
        //    Check.NotNull(userId, nameof(userId));
        //    Check.NotNullOrWhiteSpace(shippingAddress, nameof(shippingAddress));

        //    var order = new Order
        //    {
        //        Id = id,
        //        OrderNumber = orderNumber,
        //        UserId = userId,
        //        Status = OrderStatus.PendingPayment,
        //        TotalAmount = 0,
        //        PaymentMethod = paymentMethod,
        //        ShippingAddress = shippingAddress,
        //        Items = new List<OrderItem>()
        //    };

        //    return order;
        //}

        //public void AddItem(Book book, int quantity)
        //{
        //    Check.NotNull(book, nameof(book));
        //    Check.Positive(quantity, nameof(quantity));

        //    // 检查是否已存在该书籍的订单明细
        //    var existingItem = Items.FirstOrDefault(i => i.BookId == book.Id);

        //    if (existingItem != null)
        //    {
        //        existingItem.IncreaseQuantity(quantity);
        //    }
        //    else
        //    {
        //        var newItem = OrderItem.Create(
        //            GuidGenerator.Create(),
        //            Id,
        //            book.Id,
        //            book.Price,
        //            quantity
        //        );

        //        Items.Add(newItem);
        //    }

        //    // 重新计算总金额
        //    CalculateTotalAmount();
        //}

        //public void RemoveItem(Guid itemId)
        //{
        //    var item = Items.FirstOrDefault(i => i.Id == itemId);
        //    if (item != null)
        //    {
        //        Items.Remove(item);
        //        CalculateTotalAmount();
        //    }
        //}

        //private void CalculateTotalAmount()
        //{
        //    TotalAmount = Items.Sum(i => i.UnitPrice * i.Quantity);
        //}

        //public void MarkAsPaid(string transactionId)
        //{
        //    Check.NotNullOrWhiteSpace(transactionId, nameof(transactionId));

        //    if (Status != OrderStatus.PendingPayment)
        //    {
        //        throw new BusinessException(
        //            BookStoreDomainErrorCodes.InvalidOrderStatus,
        //            $"订单状态错误：当前状态为 {Status}，无法标记为已支付"
        //        );
        //    }

        //    Status = OrderStatus.Paid;
        //    PaymentTransactionId = transactionId;
        //}

        //public void MarkAsShipped()
        //{
        //    if (Status != OrderStatus.Paid)
        //    {
        //        throw new BusinessException(
        //            BookStoreDomainErrorCodes.InvalidOrderStatus,
        //            $"订单状态错误：当前状态为 {Status}，无法标记为已发货"
        //        );
        //    }

        //    Status = OrderStatus.Shipped;
        //}

        //public void MarkAsCompleted()
        //{
        //    if (Status != OrderStatus.Shipped)
        //    {
        //        throw new BusinessException(
        //            BookStoreDomainErrorCodes.InvalidOrderStatus,
        //            $"订单状态错误：当前状态为 {Status}，无法标记为已完成"
        //        );
        //    }

        //    Status = OrderStatus.Completed;
        //}

        //public void Cancel()
        //{
        //    if (Status == OrderStatus.Completed || Status == OrderStatus.Canceled)
        //    {
        //        throw new BusinessException(
        //            BookStoreDomainErrorCodes.InvalidOrderStatus,
        //            $"订单状态错误：当前状态为 {Status}，无法取消"
        //        );
        //    }

        //    Status = OrderStatus.Canceled;
        //}
    }
}