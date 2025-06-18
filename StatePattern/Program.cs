
//在状态模式（State Pattern）中，类的行为是基于它的状态改变的，这种类型的设计模式属于行为型模式
//状态模式：关注对象的内部状态变化，状态转换逻辑封装在状态类中。


//状态模式包含以下几个主要角色：

//上下文（Context）：定义了客户感兴趣的接口，并维护一个当前状态对象的引用。上下文可以通过状态对象来委托处理状态相关的行为。

//状态（State）：定义了一个接口，用于封装与上下文相关的一个状态的行为。

//具体状态（Concrete State）：实现了状态接口，负责处理与该状态相关的行为。
//具体状态对象通常会在内部维护一个对上下文对象的引用，以便根据不同的条件切换到不同的状态。


Document doc = new Document();

        // 草稿 -> 审核中
        doc.Review();
        Console.WriteLine("当前状态：" + doc.GetCurrentStatus());
        Console.WriteLine();

        // 审核中 -> 已发布
        doc.Publish();
        Console.WriteLine("当前状态：" + doc.GetCurrentStatus());
        Console.WriteLine();

        // 尝试对已发布文档进行不合法操作
        doc.Reject();
        Console.WriteLine("当前状态：" + doc.GetCurrentStatus());
        Console.WriteLine();

        // 尝试对已发布文档进行审核
        doc.Review();
        Console.WriteLine("当前状态：" + doc.GetCurrentStatus());
