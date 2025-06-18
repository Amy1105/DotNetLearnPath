
/// <summary>
/// 处理者抽象类
/// </summary>
public abstract class DiscountHandler
{
    protected DiscountHandler _nextHandler;

    public DiscountHandler SetNext(DiscountHandler handler)
    {
        _nextHandler = handler;
        return handler; // 支持链式调用
    }

    public abstract void Handle(DiscountRequest request);
}
