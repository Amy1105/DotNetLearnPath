
/// <summary>
/// 具体实现类
/// </summary>
public class RealCustomer : Customer
{
    private readonly string _name;

    public RealCustomer(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name), "客户名称不能为空");
        }

        _name = name;
    }

    public override string Name => _name;

    public override void BuyProduct(string product)
    {
        Console.WriteLine($"{_name} 购买了 {product}");
    }

    public override bool IsNull => false;
}
