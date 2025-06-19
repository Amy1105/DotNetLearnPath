
/// <summary>
/// 客户工厂类
/// </summary>
public static class CustomerFactory
{
    public static Customer GetCustomer(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Trim().ToLower() == "unknown")
        {
            return new NullCustomer();
        }

        return new RealCustomer(name);
    }
}
