using System;

// 子系统类A
public class SubsystemA
{
    public string OperationA()
    {
        return "SubsystemA: OperationA\n";
    }
}

// 子系统类B
public class SubsystemB
{
    public string OperationB()
    {
        return "SubsystemB: OperationB\n";
    }
}

// 子系统类C
public class SubsystemC
{
    public string OperationC()
    {
        return "SubsystemC: OperationC\n";
    }
}

// 外观类：提供简化接口
public class Facade
{
    private SubsystemA _subsystemA;
    private SubsystemB _subsystemB;
    private SubsystemC _subsystemC;

    public Facade()
    {
        _subsystemA = new SubsystemA();
        _subsystemB = new SubsystemB();
        _subsystemC = new SubsystemC();
    }

    // 简化的高级接口
    public string Operation1()
    {
        return "Facade Operation1:\n" +
               _subsystemA.OperationA() +
               _subsystemB.OperationB();
    }

    // 简化的高级接口
    public string Operation2()
    {
        return "Facade Operation2:\n" +
               _subsystemB.OperationB() +
               _subsystemC.OperationC();
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 通过外观类访问子系统
        Facade facade = new Facade();

        Console.WriteLine("客户端通过外观类调用 Operation1:");
        Console.WriteLine(facade.Operation1());

        Console.WriteLine("\n客户端通过外观类调用 Operation2:");
        Console.WriteLine(facade.Operation2());

        Console.WriteLine("\n客户端也可以直接访问子系统:");
        Console.WriteLine(new SubsystemA().OperationA());
        Console.WriteLine(new SubsystemB().OperationB());
        Console.WriteLine(new SubsystemC().OperationC());
    }
}