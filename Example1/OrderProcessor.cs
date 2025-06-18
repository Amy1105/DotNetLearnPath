
using System.Reactive.Subjects;

/// <summary>
/// 中介者接口
/// </summary>
public class OrderProcessor : IOrderMediator, IObservable<OrderEvent>, IDisposable
{
    private readonly Subject<OrderEvent> _subject = new();

    // 协调订单处理流程
    public void ProcessOrder(string orderId, string productId, int quantity)
    {
        // 1. 验证库存（中介者协调）
        if (!CheckInventory(productId, quantity))
        {
            _subject.OnNext(new OrderEvent
            {
                OrderId = orderId,
                Message = "库存不足"
            });
            return;
        }

        // 2. 处理支付
        ProcessPayment(orderId);

        // 3. 通知观察者
        _subject.OnNext(new OrderEvent
        {
            OrderId = orderId,
            Message = "订单处理完成"
        });
    }

    // 观察者模式实现
    public IDisposable Subscribe(IObserver<OrderEvent> observer)
        => _subject.Subscribe(observer);

    private bool CheckInventory(string productId, int quantity)
        => true; // 模拟库存检查

    private void ProcessPayment(string orderId)
        => Console.WriteLine($"处理支付: {orderId}");

    public void Dispose() => _subject.Dispose();

    void IOrderMediator.Subscribe(IObserver<OrderEvent> observer)
    {
        throw new NotImplementedException();
    }
}
