
/// <summary>
/// 对象适配器：通过组合实现适配
/// </summary>
public class ObjectAdapter : ITarget
{
    private readonly Adaptee _adaptee;

    public ObjectAdapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string Request()
    {
        // 调用适配者的方法并转换结果
        return _adaptee.SpecificRequest();
    }
}
