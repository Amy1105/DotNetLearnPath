
/// <summary>
/// 管理者类：负责保存和管理备忘录
/// </summary>
public class Caretaker
{
    private readonly Stack<Memento> history = new Stack<Memento>();

    public void SaveState(TextEditor editor)
    {
        history.Push(editor.CreateMemento());
        Console.WriteLine("已保存当前状态");
    }

    public void Undo(TextEditor editor)
    {
        if (history.Count == 0)
        {
            Console.WriteLine("没有可恢复的历史状态");
            return;
        }

        var memento = history.Pop();
        editor.RestoreMemento(memento);
    }
}
