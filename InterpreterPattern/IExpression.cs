
/// <summary>
/// 抽象表达式接口
/// </summary>
public interface IExpression
{
    bool Interpret(Dictionary<string, bool> context);
}
