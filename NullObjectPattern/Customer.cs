
/// <summary>
/// 定义一个抽象基类或接口
/// </summary>
public abstract class Customer
{
    public abstract string Name { get; }
    public abstract void BuyProduct(string product);
    public abstract bool IsNull { get; }
}
