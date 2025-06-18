
/// <summary>
/// 处理者抽象类
/// </summary>

public class VipCustomerHandler : DiscountHandler
{
    public override void Handle(DiscountRequest request)
    {
        if (request.CustomerLevel == "VIP")
        {
            request.FinalPrice = request.OriginalPrice * 0.8m;
            Console.WriteLine($"VIP客户8折，最终价格: {request.FinalPrice}");
        }
        else
        {
            _nextHandler?.Handle(request);
        }
    }
}
