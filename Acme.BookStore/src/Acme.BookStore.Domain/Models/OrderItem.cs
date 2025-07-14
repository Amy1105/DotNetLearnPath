using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp;

namespace Acme.BookStore.Orders
{
    /// <summary>
    /// 订单明细实体
    /// </summary>
    public class OrderItem : Entity<Guid>
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// 书籍ID
        /// </summary>
        public Guid BookId { get; private set; }

        /// <summary>
        /// 购买价格（下单时的价格）
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; private set; }

        //private OrderItem() { }

        //public static OrderItem Create(
        //    Guid id,
        //    Guid orderId,
        //    Guid bookId,
        //    decimal unitPrice,
        //    int quantity)
        //{
        //    Check.NotNull(id, nameof(id));
        //    Check.NotNull(orderId, nameof(orderId));
        //    Check.NotNull(bookId, nameof(bookId));
        //    Check.Range(unitPrice, nameof(unitPrice), 0, decimal.MaxValue);
        //    Check.Positive(quantity, nameof(quantity));

        //    return new OrderItem
        //    {
        //        Id = id,
        //        OrderId = orderId,
        //        BookId = bookId,
        //        UnitPrice = unitPrice,
        //        Quantity = quantity
        //    };
        //}

        //public void IncreaseQuantity(int additionalQuantity)
        //{
        //    Check.Positive(additionalQuantity, nameof(additionalQuantity));
        //    Quantity += additionalQuantity;
        //}

        //public void DecreaseQuantity(int reductionQuantity)
        //{
        //    Check.Positive(reductionQuantity, nameof(reductionQuantity));

        //    if (reductionQuantity > Quantity)
        //    {
        //        throw new BusinessException(
        //            BookStoreDomainErrorCodes.InvalidQuantity,
        //            $"减少的数量不能大于当前数量：{Quantity}"
        //        );
        //    }

        //    Quantity -= reductionQuantity;
        //}

        //public void SetQuantity(int newQuantity)
        //{
        //    Check.Positive(newQuantity, nameof(newQuantity));
        //    Quantity = newQuantity;
        //}
    }
}
