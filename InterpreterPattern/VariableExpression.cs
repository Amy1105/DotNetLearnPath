
/// <summary>
/// 变量表达式
/// </summary>
public class VariableExpression : IExpression
{
    private string name;

    public VariableExpression(string name)
    {
        this.name = name;
    }

    public bool Interpret(Dictionary<string, bool> context)
    {
        if (!context.ContainsKey(name))
            throw new ArgumentException($"未定义的变量: {name}");

        return context[name];
    }
}
