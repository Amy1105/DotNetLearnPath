
/// <summary>
/// 类适配器：通过继承实现适配
/// </summary>
public class ClassAdapter : Adaptee, ITarget
{
    public string Request()
    {
        // 调用适配者的方法并转换结果
        return SpecificRequest();
    }
}
