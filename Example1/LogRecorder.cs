
/// <summary>
/// 日志记录观察者
/// </summary>
public class LogRecorder : IObserver<OrderEvent>
{
    public void OnNext(OrderEvent value) =>
        Console.WriteLine($"[日志] {DateTime.Now}: {value.OrderId} -> {value.Message}");

    public void OnError(Exception error) { }
    public void OnCompleted() { }
}
