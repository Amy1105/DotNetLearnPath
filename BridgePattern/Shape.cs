
/// <summary>
/// 抽象类：定义抽象部分的接口，并持有一个实现部分的引用
/// </summary>
public abstract class Shape
{
    protected IColor color;

    public Shape(IColor color)
    {
        this.color = color;
    }

    public abstract string Draw();
}
