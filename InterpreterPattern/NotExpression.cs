
/// <summary>
/// NOT表达式
/// </summary>
public class NotExpression : IExpression
{
    private IExpression expression;

    public NotExpression(IExpression expression)
    {
        this.expression = expression;
    }

    public bool Interpret(Dictionary<string, bool> context)
    {
        return !expression.Interpret(context);
    }
}
