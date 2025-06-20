
// 具体抽象类：正方形
public class Square : Shape
{
    public Square(IColor color) : base(color)
    {
    }

    public override string Draw()
    {
        return $"Square drawn. {color.Fill()}";
    }
}
