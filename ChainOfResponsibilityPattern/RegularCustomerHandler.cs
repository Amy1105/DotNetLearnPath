
/// <summary>
/// 处理者抽象类
/// </summary>
public class RegularCustomerHandler : DiscountHandler
{
    public override void Handle(DiscountRequest request)
    {
        if (request.CustomerLevel == "Regular" && request.OriginalPrice >= 100)
        {
            request.FinalPrice = request.OriginalPrice - 10;
            Console.WriteLine($"普通客户满100减10，最终价格: {request.FinalPrice}");
        }
        else
        {
            _nextHandler?.Handle(request); // 传递给下一个处理者
        }
    }
}
