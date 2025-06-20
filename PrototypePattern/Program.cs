using System;
using System.Collections.Generic;

// 原型接口
public interface IPrototype
{
    IPrototype Clone();
}

// 具体原型类：员工
public class Employee : IPrototype
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Department Department { get; set; }

    public Employee(string name, int age, Department department)
    {
        Name = name;
        Age = age;
        Department = department;
    }

    // 浅克隆实现
    public IPrototype Clone()
    {
        return (IPrototype)MemberwiseClone();
    }

    // 深克隆实现
    public IPrototype DeepClone()
    {
        Employee clone = (Employee)MemberwiseClone();
        clone.Department = new Department(Department.Name);
        return clone;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Department: {Department.Name}";
    }
}

// 引用类型：部门
public class Department
{
    public string Name { get; set; }

    public Department(string name)
    {
        Name = name;
    }
}

// 原型管理器
public class PrototypeManager
{
    private Dictionary<string, IPrototype> _prototypes = new Dictionary<string, IPrototype>();

    public IPrototype this[string key]
    {
        get { return _prototypes[key].Clone(); }
        set { _prototypes[key] = value; }
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 创建原型对象
        Department hrDepartment = new Department("HR");
        Employee originalEmployee = new Employee("John Doe", 30, hrDepartment);

        Console.WriteLine("Original Employee:");
        Console.WriteLine(originalEmployee);

        // 浅克隆
        Employee shallowClone = (Employee)originalEmployee.Clone();
        shallowClone.Name = "Jane Smith";
        shallowClone.Department.Name = "Finance";

        Console.WriteLine("\nShallow Clone:");
        Console.WriteLine(shallowClone);
        Console.WriteLine("Original Employee after shallow clone:");
        Console.WriteLine(originalEmployee); // 注意部门名称已被修改

        // 深克隆
        Employee deepClone = (Employee)originalEmployee.DeepClone();
        deepClone.Name = "Bob Johnson";
        deepClone.Department.Name = "IT";

        Console.WriteLine("\nDeep Clone:");
        Console.WriteLine(deepClone);
        Console.WriteLine("Original Employee after deep clone:");
        Console.WriteLine(originalEmployee); // 部门名称保持不变

        // 使用原型管理器
        PrototypeManager manager = new PrototypeManager();
        manager["standardEmployee"] = originalEmployee;

        Employee clonedFromManager = (Employee)manager["standardEmployee"];
        clonedFromManager.Name = "Alice Williams";

        Console.WriteLine("\nCloned from PrototypeManager:");
        Console.WriteLine(clonedFromManager);
    }
}