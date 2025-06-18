
/// <summary>
/// 命令接口:定义了执行和撤销操作
/// </summary>
public interface ICommand
{
    void Execute();
    void Undo();
}
