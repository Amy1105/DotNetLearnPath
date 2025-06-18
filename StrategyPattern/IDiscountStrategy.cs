
/// <summary>
/// 策略接口：定义折扣算法
/// </summary>
public interface IDiscountStrategy
{
    double CalculateDiscount(double price);
}
