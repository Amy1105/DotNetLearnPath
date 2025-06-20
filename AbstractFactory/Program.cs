using System;

// 产品A接口
public interface IProductA
{
    string UsefulFunctionA();
}

// 产品A的具体实现（系列1）
public class ConcreteProductA1 : IProductA
{
    public string UsefulFunctionA()
    {
        return "The result of product A1.";
    }
}

// 产品A的具体实现（系列2）
public class ConcreteProductA2 : IProductA
{
    public string UsefulFunctionA()
    {
        return "The result of product A2.";
    }
}

// 产品B接口
public interface IProductB
{
    string UsefulFunctionB();
    // 产品B可以与产品A协作
    string AnotherUsefulFunctionB(IProductA collaborator);
}

// 产品B的具体实现（系列1）
public class ConcreteProductB1 : IProductB
{
    public string UsefulFunctionB()
    {
        return "The result of product B1.";
    }

    public string AnotherUsefulFunctionB(IProductA collaborator)
    {
        var result = collaborator.UsefulFunctionA();
        return $"The result of the B1 collaborating with ({result})";
    }
}

// 产品B的具体实现（系列2）
public class ConcreteProductB2 : IProductB
{
    public string UsefulFunctionB()
    {
        return "The result of product B2.";
    }

    public string AnotherUsefulFunctionB(IProductA collaborator)
    {
        var result = collaborator.UsefulFunctionA();
        return $"The result of the B2 collaborating with ({result})";
    }
}

// 抽象工厂接口：定义创建系列产品的方法
public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

// 具体工厂1：创建系列1的产品
public class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

// 具体工厂2：创建系列2的产品
public class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

// 客户端代码：使用抽象工厂创建产品系列
class Client
{
    private readonly IProductA _productA;
    private readonly IProductB _productB;

    public Client(IAbstractFactory factory)
    {
        _productA = factory.CreateProductA();
        _productB = factory.CreateProductB();
    }

    public void Run()
    {
        Console.WriteLine(_productB.UsefulFunctionB());
        Console.WriteLine(_productB.AnotherUsefulFunctionB(_productA));
    }
}

// 示例用法
class Program
{
    static void Main()
    {
        Console.WriteLine("Client: Testing client code with the first factory type:");
        Client client1 = new Client(new ConcreteFactory1());
        client1.Run();

        Console.WriteLine();

        Console.WriteLine("Client: Testing the same client code with the second factory type:");
        Client client2 = new Client(new ConcreteFactory2());
        client2.Run();
    }
}