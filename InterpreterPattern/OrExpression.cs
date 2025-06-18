
/// <summary>
/// OR表达式
/// </summary>
public class OrExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public OrExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public bool Interpret(Dictionary<string, bool> context)
    {
        return left.Interpret(context) || right.Interpret(context);
    }
}
