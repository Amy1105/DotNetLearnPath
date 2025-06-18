
/// <summary>
/// 调用者：遥控器  通过命令对象间接调用接收者的方法
/// </summary>
public class RemoteControl
{
    private ICommand[] onCommands;
    private ICommand[] offCommands;
    private Stack<ICommand> commandHistory; // 用于撤销操作

    public RemoteControl()
    {
        onCommands = new ICommand[7];
        offCommands = new ICommand[7];
        commandHistory = new Stack<ICommand>();

        // 初始化所有插槽为空命令
        ICommand noCommand = new NoCommand();
        for (int i = 0; i < 7; i++)
        {
            onCommands[i] = noCommand;
            offCommands[i] = noCommand;
        }
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        onCommands[slot] = onCommand;
        offCommands[slot] = offCommand;
    }

    public void PressOnButton(int slot)
    {
        onCommands[slot].Execute();
        commandHistory.Push(onCommands[slot]);
    }

    public void PressOffButton(int slot)
    {
        offCommands[slot].Execute();
        commandHistory.Push(offCommands[slot]);
    }

    public void PressUndoButton()
    {
        if (commandHistory.Count > 0)
        {
            ICommand command = commandHistory.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("没有可撤销的命令");
        }
    }

    public override string ToString()
    {
        string result = "\n------ 遥控器 ------\n";
        for (int i = 0; i < onCommands.Length; i++)
        {
            result += $"[插槽 {i}] {onCommands[i].GetType().Name,-25}" +
                      $" {offCommands[i].GetType().Name,-25}\n";
        }
        return result;
    }
}
