// 责任链模式：为请求创建了一个接收者对象的链。这种模式给予请求的类型，对请求的发送者和接收者进行解耦。
// 这种类型的设计模式属于行为型模式

//主要涉及到以下几个核心角色：

//抽象处理者（Handler）:
//定义一个处理请求的接口，通常包含一个处理请求的方法（如 handleRequest）和一个指向下一个处理者的引用（后继者）。

//具体处理者（ConcreteHandler）:
//实现了抽象处理者接口，负责处理请求。如果能够处理该请求，则直接处理；否则，将请求传递给下一个处理者。

//客户端（Client）:
//创建处理者对象，并将它们连接成一条责任链。通常，客户端只需要将请求发送给责任链的第一个处理者，无需关心请求的具体处理过程。


// 1. 构建责任链
var handlerChain = new RegularCustomerHandler();
        handlerChain.SetNext(new VipCustomerHandler()).SetNext(new SuperVipCustomerHandler());

// 2. 模拟订单请求
var requests = new List<DiscountRequest>
        {
            new() { OrderId = "001", OriginalPrice = 150, CustomerLevel = "Regular" },
            new() { OrderId = "002", OriginalPrice = 200, CustomerLevel = "VIP" },
            new() { OrderId = "003", OriginalPrice = 300, CustomerLevel = "SuperVIP" },
            new() { OrderId = "004", OriginalPrice = 50, CustomerLevel = "Regular" }
        };

// 3. 处理每个订单
foreach (var request in requests)
{
    Console.WriteLine($"\n处理订单 {request.OrderId}: 原价={request.OriginalPrice}, 客户={request.CustomerLevel}");
    request.FinalPrice = request.OriginalPrice; // 初始化
    handlerChain.Handle(request);
}
