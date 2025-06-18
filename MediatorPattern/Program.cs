// 中介者模式：行为型模式之一（解决对象之间的责任分配和算法的封装）


//中介者模式包含以下几个主要角色：
//中介者（Mediator）：定义了一个接口用于与各个同事对象通信，并管理各个同事对象之间的关系。
//通常包括一个或多个事件处理方法，用于处理各种交互事件。

//具体中介者（Concrete Mediator）：实现了中介者接口，负责实现各个同事对象之间的通信逻辑。
//它会维护一个对各个同事对象的引用，并协调它们的交互。

//同事对象（Colleague）：定义了一个接口，用于与中介者进行通信。通常包括一个发送消息的方法，以及一个接收消息的方法。

//具体同事对象（Concrete Colleague）：实现了同事对象接口，是真正参与到交互中的对象。
//它会将自己的消息发送给中介者，由中介者转发给其他同事对象。


var mediator = new ManagerMediator();
var customer = new Customer(mediator);
var programmer = new Programmer(mediator);
var tester = new Tester(mediator);
mediator.Customer = customer;
mediator.Programmer = programmer;
mediator.Tester = tester;
customer.Send("We have an order, need to make a program");
programmer.Send("I have done program, need to test it");
tester.Send("I have done testing, here is ready program for you");
Console.Read();