
/// <summary>
/// 空对象实现
/// </summary>
public class NullCustomer : Customer
{
    public override string Name => "未知客户";

    public override void BuyProduct(string product)
    {
        Console.WriteLine("无法处理购买请求：客户信息缺失");
    }

    public override bool IsNull => true;
}
