//桥接模式的核心是通过组合（持有引用）而不是继承来实现抽象和实现的解耦，使得两者可以独立变化。


// 创建具体的实现对象
IColor redColor = new RedColor();
        IColor blueColor = new BlueColor();

        // 创建具体的抽象对象，并将实现对象注入
        Shape redCircle = new Circle(redColor);
        Shape blueSquare = new Square(blueColor);

        // 客户端通过抽象接口操作对象
        Console.WriteLine(redCircle.Draw());
        Console.WriteLine(blueSquare.Draw());
