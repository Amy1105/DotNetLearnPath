using System;

// 组件接口：定义基本操作
public interface IComponent
{
    string Operation();
}

// 具体组件：实现基本功能
public class ConcreteComponent : IComponent
{
    public string Operation()
    {
        return "ConcreteComponent";
    }
}

// 装饰器抽象类：维持一个指向组件对象的引用
public abstract class Decorator : IComponent
{
    protected IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public virtual string Operation()
    {
        return _component.Operation();
    }
}

// 具体装饰器A：添加额外职责
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override string Operation()
    {
        // 在原有操作基础上添加额外操作
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}

// 具体装饰器B：添加额外职责
public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override string Operation()
    {
        // 在原有操作基础上添加额外操作
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 创建原始组件
        IComponent component = new ConcreteComponent();
        Console.WriteLine("原始组件: " + component.Operation());

        // 使用装饰器A包装组件
        IComponent decoratorA = new ConcreteDecoratorA(component);
        Console.WriteLine("装饰器A包装后: " + decoratorA.Operation());

        // 使用装饰器B包装组件
        IComponent decoratorB = new ConcreteDecoratorB(component);
        Console.WriteLine("装饰器B包装后: " + decoratorB.Operation());

        // 嵌套装饰：使用装饰器B包装装饰器A
        IComponent decoratorAB = new ConcreteDecoratorB(decoratorA);
        Console.WriteLine("装饰器A和B嵌套包装后: " + decoratorAB.Operation());
    }
}