using System;

// 方式1：懒汉式（线程不安全）
public class SingletonV1
{
    private static SingletonV1 _instance;

    private SingletonV1() { }

    public static SingletonV1 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SingletonV1();
            }
            return _instance;
        }
    }
}

// 方式2：懒汉式（线程安全，双重检查锁定）
public class SingletonV2
{
    private static SingletonV2 _instance;
    private static readonly object _lock = new object();

    private SingletonV2() { }

    public static SingletonV2 Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonV2();
                    }
                }
            }
            return _instance;
        }
    }
}

// 方式3：饿汉式（静态初始化）
public class SingletonV3
{
    private static readonly SingletonV3 _instance = new SingletonV3();

    private SingletonV3() { }

    public static SingletonV3 Instance => _instance;
}

// 方式4：静态内部类（推荐）
public class SingletonV4
{
    private SingletonV4() { }

    private static class SingletonHolder
    {
        public static readonly SingletonV4 Instance = new SingletonV4();
    }

    public static SingletonV4 Instance => SingletonHolder.Instance;
}

// 方式5：带泛型的单例基类
public abstract class SingletonBase<T> where T : class, new()
{
    private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

    public static T Instance => _instance.Value;
}

// 使用泛型基类的示例
public class MySingleton : SingletonBase<MySingleton>
{
    public void DoSomething()
    {
        Console.WriteLine("MySingleton is doing something.");
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 测试各种单例实现
        Console.WriteLine("SingletonV1: " + SingletonV1.Instance.GetHashCode());
        Console.WriteLine("SingletonV2: " + SingletonV2.Instance.GetHashCode());
        Console.WriteLine("SingletonV3: " + SingletonV3.Instance.GetHashCode());
        Console.WriteLine("SingletonV4: " + SingletonV4.Instance.GetHashCode());

        // 使用泛型单例
        MySingleton.Instance.DoSomething();
    }
}