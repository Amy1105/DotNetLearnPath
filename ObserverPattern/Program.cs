
//观察者模式是一种行为型设计模式，它定义了一种一对多的依赖关系，当一个对象的状态发生改变时，
//其所有依赖者都会收到通知并自动更新。

//观察者模式包含以下几个核心角色：

//主题（Subject）：也称为被观察者或可观察者，它是具有状态的对象，并维护着一个观察者列表。
//主题提供了添加、删除和通知观察者的方法。

//观察者（Observer）：观察者是接收主题通知的对象。观察者需要实现一个更新方法，当收到主题的通知时，调用该方法进行更新操作。

//具体主题（Concrete Subject）：具体主题是主题的具体实现类。它维护着观察者列表，并在状态发生改变时通知观察者。

//具体观察者（Concrete Observer）：具体观察者是观察者的具体实现类。它实现了更新方法，
//定义了在收到主题通知时需要执行的具体操作。

//观察者模式通过将主题和观察者解耦，实现了对象之间的松耦合。当主题的状态发生改变时，
//所有依赖于它的观察者都会收到通知并进行相应的更新。



// 创建气象站和显示设备
WeatherStation weatherStation = new WeatherStation();
PhoneDisplay phoneDisplay = new PhoneDisplay();
WebDisplay webDisplay = new WebDisplay();

// 注册观察者
weatherStation.RegisterObserver(phoneDisplay);
weatherStation.RegisterObserver(webDisplay);

// 模拟天气变化
weatherStation.SetMeasurements(25.5f, 65.2f, 1013.2f);
Console.WriteLine();

// 移除一个观察者
weatherStation.RemoveObserver(webDisplay);

// 再次模拟天气变化
weatherStation.SetMeasurements(26.8f, 61.7f, 1014.5f);
