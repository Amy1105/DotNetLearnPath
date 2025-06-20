using System;
using System.Collections.Generic;

// 组件抽象类：定义叶子和组合对象的公共接口
public abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    // 添加子组件
    public abstract void Add(Component component);

    // 移除子组件
    public abstract void Remove(Component component);

    // 显示组件结构
    public abstract void Display(int depth);
}

// 叶子节点：没有子节点的组件
public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    // 叶子节点不能添加子节点
    public override void Add(Component component)
    {
        Console.WriteLine("Cannot add to a leaf");
    }

    // 叶子节点不能移除子节点
    public override void Remove(Component component)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }

    // 显示叶子节点信息
    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + name);
    }
}

// 组合节点：可以包含叶子节点和其他组合节点
public class Composite : Component
{
    private List<Component> children = new List<Component>();

    public Composite(string name) : base(name)
    {
    }

    // 添加子组件
    public override void Add(Component component)
    {
        children.Add(component);
    }

    // 移除子组件
    public override void Remove(Component component)
    {
        children.Remove(component);
    }

    // 显示组合节点及其子节点的结构
    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + name);

        foreach (Component component in children)
        {
            component.Display(depth + 2);
        }
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 创建树形结构
        Composite root = new Composite("Root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        root.Add(comp);
        root.Add(new Leaf("Leaf C"));

        // 添加更深层次的节点
        Composite comp2 = new Composite("Composite XY");
        comp2.Add(new Leaf("Leaf XYA"));
        comp2.Add(new Leaf("Leaf XYB"));

        comp.Add(comp2);

        // 移除一个叶子节点
        root.Remove(new Leaf("Leaf C"));

        // 显示整棵树
        root.Display(1);
    }
}