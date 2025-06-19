//空对象模式是一种行为设计模式，它让你可以用一个 “空对象” 替代空引用（null），从而避免在代码中进行显式的空值检查

//空对象模式包含以下几个主要角色：

//抽象对象（Abstract Object）：定义了客户端所期望的接口。这个接口可以是一个抽象类或接口。

//具体对象（Concrete Object）：实现了抽象对象接口的具体类。这些类提供了真实的行为。

//空对象（Null Object）：实现了抽象对象接口的空对象类。这个类提供了默认的无效行为，以便在对象不可用或不可用时使用。它可以作为具体对象的替代者，在客户端代码中代替空值检查。


Customer customer1 = CustomerFactory.GetCustomer("张三");
        Customer customer2 = CustomerFactory.GetCustomer(null);
        Customer customer3 = CustomerFactory.GetCustomer("unknown");

        ProcessCustomer(customer1);
        ProcessCustomer(customer2);
        ProcessCustomer(customer3);


    static void ProcessCustomer(Customer customer)
{
    Console.WriteLine($"客户名称: {customer.Name}");
    customer.BuyProduct("笔记本电脑");

    if (customer.IsNull)
    {
        Console.WriteLine("注意: 这是一个空对象");
    }

    Console.WriteLine();
}