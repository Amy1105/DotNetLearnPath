
/// <summary>
/// AND表达式
/// </summary>
public class AndExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public AndExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public bool Interpret(Dictionary<string, bool> context)
    {
        return left.Interpret(context) && right.Interpret(context);
    }
}
