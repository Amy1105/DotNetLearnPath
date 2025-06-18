//解释器模式给定一个语言，定义它的文法的一种表示，并定义一个解释器，这个解释器使用该表示来解释语言中的句子。
//这种模式被用在 SQL 解析、符号处理引擎等

//解释器模式包含以下几个主要角色：

//抽象表达式（Abstract Expression）：定义了解释器的抽象接口，声明了解释操作的方法，通常是一个抽象类或接口。

//终结符表达式（Terminal Expression）：实现了抽象表达式接口的终结符表达式类，用于表示语言中的终结符（如变量、常量等），并实现了对应的解释操作。

//非终结符表达式（Non-terminal Expression）：实现了抽象表达式接口的非终结符表达式类，用于表示语言中的非终结符（如句子、表达式等），并实现了对应的解释操作。

//上下文（Context）：包含解释器之外的一些全局信息，在解释过程中提供给解释器使用，通常用于存储变量的值、保存解释器的状态等。

//客户端（Client）：创建并配置具体的解释器对象，并将需要解释的表达式传递给解释器进行解释。


        // 创建表达式: (x AND y) OR (NOT z)
        IExpression x = new VariableExpression("x");
        IExpression y = new VariableExpression("y");
        IExpression z = new VariableExpression("z");

        IExpression andExpr = new AndExpression(x, y);
        IExpression notExpr = new NotExpression(z);
        IExpression orExpr = new OrExpression(andExpr, notExpr);

        // 设置上下文变量
        Context context = new Context();
        context.Assign("x", true);
        context.Assign("y", false);
        context.Assign("z", false);

        // 解释表达式
        Dictionary<string, bool> contextDict = new Dictionary<string, bool>
        {
            { "x", true },
            { "y", false },
            { "z", false }
        };

        bool result = orExpr.Interpret(contextDict);
        Console.WriteLine("表达式 (x AND y) OR (NOT z) 的计算结果: " + result); // 输出: True
