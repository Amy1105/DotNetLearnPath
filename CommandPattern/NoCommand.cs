
/// <summary>
/// 空命令（用于初始化遥控器插槽）
/// </summary>
public class NoCommand : ICommand
{
    public void Execute() { }
    public void Undo() { }
}
