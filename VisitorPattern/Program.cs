
//在访问者模式（Visitor Pattern）中，我们使用了一个访问者类，它改变了元素类的执行算法。通过这种方式，元素的执行算法可以随着访问者改变而改变。这种类型的设计模式属于行为型模式

//包含的几个主要角色
//访问者（Visitor）：定义了访问元素的接口

//具体访问者（Concrete Visitor）：实现访问者接口，提供对每个具体元素类的访问和相应操作

//元素（Element）：定义了一个接受访问者的方法。

//具体元素（Concrete Element）：实现元素接口，提供一个accept方法，允许访问者访问并操作。

//对象结构（Object Structure）（可选）：定义了如何组装具体元素，如一个组合类。

//客户端（Client）（可选）：使用访问者模式对对象结构进行操作。

var document = new List<IDocumentElement>
        {
            new TextElement { Content = "访问者模式示例" },
            new ImageElement { FilePath = "logo.png", Width = 100, Height = 50 },
            new TableElement { Rows = 3, Columns = 2 },
            new TextElement { Content = "结束语" }
        };

        // 2. 应用Markdown访问者
        var markdownVisitor = new MarkdownVisitor();
        document.ForEach(e => e.Accept(markdownVisitor));
        Console.WriteLine("=== Markdown 输出 ===");
        Console.WriteLine(markdownVisitor.GetResult());

        // 3. 应用统计访问者
        var statsVisitor = new StatsVisitor();
        document.ForEach(e => e.Accept(statsVisitor));
        Console.WriteLine("=== 文档统计 ===");
        Console.WriteLine($"总字数: {statsVisitor.TotalWords}");
        Console.WriteLine($"图片数: {statsVisitor.TotalImages}");
        Console.WriteLine($"表格数: {statsVisitor.TotalTables}");
