//以下是一个结合 中介者模式（Mediator） 和 观察者模式（Observer） 的 C# 示例，模拟一个电商系统中的订单处理流程：

//中介者 协调订单处理（验证库存、支付、物流）

//观察者 通知相关服务（邮件、日志、数据分析）

// 创建中介者
using var mediator = new OrderProcessor();

// 注册观察者
mediator.Subscribe(new EmailNotifier());
mediator.Subscribe(new LogRecorder());

// 提交订单（通过中介者协调）
mediator.ProcessOrder("ORD-001", "PROD-100", 2);