
/// <summary>
/// 访问者接口（定义对不同元素的操作）
/// </summary>
public class TextElement : IDocumentElement
{
    public string Content { get; set; }
    public int WordCount => Content.Split(' ').Length;

    public void Accept(IDocumentVisitor visitor)
        => visitor.VisitText(this);
}
