
// 解释器上下文
public class Context
{
    private Dictionary<string, bool> variables = new Dictionary<string, bool>();

    public void Assign(string variableName, bool value)
    {
        variables[variableName] = value;
    }

    public bool Lookup(string variableName)
    {
        return variables[variableName];
    }
}
