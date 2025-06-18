
// 原发器类：创建和恢复备忘录
public class TextEditor
{
    public string Content { get; set; }
    public int CursorPosition { get; set; }

    // 创建备忘录
    public Memento CreateMemento()
    {
        return new Memento(Content, CursorPosition);
    }

    // 从备忘录恢复
    public void RestoreMemento(Memento memento)
    {
        Content = memento.Content;
        CursorPosition = memento.CursorPosition;
        Console.WriteLine("已恢复到历史状态");
    }

    public void Display()
    {
        Console.WriteLine($"当前内容: \"{Content}\"，光标位置: {CursorPosition}");
    }
}
