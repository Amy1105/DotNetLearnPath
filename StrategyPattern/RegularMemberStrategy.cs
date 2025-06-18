
/// <summary>
/// 具体策略：普通会员（无折扣）
/// </summary>
public class RegularMemberStrategy : IDiscountStrategy
{
    public double CalculateDiscount(double price)
    {
        Console.WriteLine("普通会员：无折扣");
        return price;
    }
}
