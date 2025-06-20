
// 具体抽象类：圆形
public class Circle : Shape
{
    public Circle(IColor color) : base(color)
    {
    }

    public override string Draw()
    {
        return $"Circle drawn. {color.Fill()}";
    }
}
