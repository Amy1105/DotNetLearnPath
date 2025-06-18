
/// <summary>
/// 处理者抽象类
/// </summary>
public class SuperVipCustomerHandler : DiscountHandler
{
    public override void Handle(DiscountRequest request)
    {
        if (request.CustomerLevel == "SuperVIP")
        {
            request.FinalPrice = request.OriginalPrice * 0.7m;
            Console.WriteLine($"SuperVIP客户7折，最终价格: {request.FinalPrice}");
        }
        else if (request.FinalPrice == request.OriginalPrice) // 如果前面未处理
        {
            request.FinalPrice = request.OriginalPrice * 0.9m; // 默认9折
            Console.WriteLine($"保底折扣9折，最终价格: {request.FinalPrice}");
        }
    }
}
