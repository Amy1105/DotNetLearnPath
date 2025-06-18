
/// <summary>
/// 邮件通知观察者
/// </summary>
public class EmailNotifier : IObserver<OrderEvent>
{
    public void OnNext(OrderEvent value) =>
        Console.WriteLine($"[邮件] 订单 {value.OrderId}: {value.Message}");

    public void OnError(Exception error) => throw error;
    public void OnCompleted() => Console.WriteLine("邮件通知结束");
}
