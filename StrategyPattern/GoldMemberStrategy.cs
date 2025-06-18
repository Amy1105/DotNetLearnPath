
/// <summary>
/// 具体策略：金卡会员（10%折扣）
/// </summary>
public class GoldMemberStrategy : IDiscountStrategy
{
    public double CalculateDiscount(double price)
    {
        double discountedPrice = price * 0.9;
        Console.WriteLine("金卡会员：享受10%折扣");
        return discountedPrice;
    }
}
