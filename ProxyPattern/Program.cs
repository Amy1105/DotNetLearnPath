using System;

// 主题接口：定义真实主题和代理的公共接口
public interface ISubject
{
    void Request();
}

// 真实主题：实现核心业务逻辑
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}

// 代理类：控制对真实主题的访问
public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public Proxy(RealSubject realSubject = null)
    {
        _realSubject = realSubject ?? new RealSubject();
    }

    // 访问控制逻辑
    public void Request()
    {
        if (CheckAccess())
        {
            _realSubject.Request();
            LogAccess();
        }
    }

    // 访问检查（预处理）
    private bool CheckAccess()
    {
        Console.WriteLine("Proxy: Checking access before forwarding request.");
        return true; // 示例中始终允许访问
    }

    // 日志记录（后处理）
    private void LogAccess()
    {
        Console.WriteLine("Proxy: Logging the time of request.");
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        Console.WriteLine("Client: Executing the client code with a proxy:");

        // 通过代理访问真实主题
        Proxy proxy = new Proxy();
        proxy.Request();
    }
}