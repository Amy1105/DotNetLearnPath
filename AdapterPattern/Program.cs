
//客户端可以通过 ITarget 接口统一调用适配后的方法，无需关心具体的适配细节。
//两种适配器都将 Adaptee 的 SpecificRequest 方法转换为 ITarget 接口的 Request 方法



Client client = new Client();

        // 使用类适配器
        Console.WriteLine("Using Class Adapter:");
        ITarget classAdapter = new ClassAdapter();
        client.UseTarget(classAdapter);

        Console.WriteLine();

        // 使用对象适配器
        Console.WriteLine("Using Object Adapter:");
        Adaptee adaptee = new Adaptee();
        ITarget objectAdapter = new ObjectAdapter(adaptee);
        client.UseTarget(objectAdapter);
