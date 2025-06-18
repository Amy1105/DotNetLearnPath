
/// <summary>
/// 常量表达式
/// </summary>
public class ConstantExpression : IExpression
{
    private bool value;

    public ConstantExpression(bool value)
    {
        this.value = value;
    }

    public bool Interpret(Dictionary<string, bool> context)
    {
        return value;
    }
}
