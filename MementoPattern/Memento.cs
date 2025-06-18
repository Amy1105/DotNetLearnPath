
// 备忘录类：保存原发器的内部状态
public class Memento
{
    public string Content { get; }
    public int CursorPosition { get; }

    public Memento(string content, int cursorPosition)
    {
        Content = content;
        CursorPosition = cursorPosition;
    }
}
