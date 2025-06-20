
// 客户端代码
public class Client
{
    public void UseTarget(ITarget target)
    {
        Console.WriteLine(target.Request());
    }
}
