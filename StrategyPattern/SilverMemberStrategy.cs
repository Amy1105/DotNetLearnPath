
/// <summary>
/// 具体策略：银卡会员（5%折扣）
/// </summary>
public class SilverMemberStrategy : IDiscountStrategy
{
    public double CalculateDiscount(double price)
    {
        double discountedPrice = price * 0.95;
        Console.WriteLine("银卡会员：享受5%折扣");
        return discountedPrice;
    }
}
