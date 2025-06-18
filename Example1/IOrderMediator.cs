
/// <summary>
/// 中介者接口
/// </summary>
public interface IOrderMediator
{
    void ProcessOrder(string orderId, string productId, int quantity);
    void Subscribe(IObserver<OrderEvent> observer);
}
