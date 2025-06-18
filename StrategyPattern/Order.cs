
// 上下文：订单类
public class Order
{
    private IDiscountStrategy discountStrategy;
    public double TotalPrice { get; set; }

    public Order(double totalPrice, IDiscountStrategy strategy)
    {
        TotalPrice = totalPrice;
        discountStrategy = strategy;
    }

    public void SetDiscountStrategy(IDiscountStrategy strategy)
    {
        discountStrategy = strategy;
    }

    public double CalculateFinalPrice()
    {
        return discountStrategy.CalculateDiscount(TotalPrice);
    }
}
