using System;

// 产品接口
public interface IProduct
{
    string Operation();
}

// 具体产品A
public class ConcreteProductA : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProductA}";
    }
}

// 具体产品B
public class ConcreteProductB : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProductB}";
    }
}

// 创建者抽象类
public abstract class Creator
{
    // 工厂方法
    public abstract IProduct FactoryMethod();

    // 核心业务逻辑
    public string SomeOperation()
    {
        // 调用工厂方法创建产品
        var product = FactoryMethod();

        // 使用产品
        return $"Creator: The same creator's code has just worked with {product.Operation()}";
    }
}

// 具体创建者A
public class ConcreteCreatorA : Creator
{
    // 实现工厂方法，返回具体产品A
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

// 具体创建者B
public class ConcreteCreatorB : Creator
{
    // 实现工厂方法，返回具体产品B
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        Console.WriteLine("App: Launched with the ConcreteCreatorA.");
        ClientCode(new ConcreteCreatorA());

        Console.WriteLine();

        Console.WriteLine("App: Launched with the ConcreteCreatorB.");
        ClientCode(new ConcreteCreatorB());
    }

    // 客户端代码依赖于抽象接口
    static void ClientCode(Creator creator)
    {
        Console.WriteLine("Client: I'm not aware of the creator's class," +
            "but it still works.\n" + creator.SomeOperation());
    }
}