
/// <summary>
/// 访问者接口（定义对不同元素的操作）
/// </summary>
public class ImageElement : IDocumentElement
{
    public string FilePath { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public void Accept(IDocumentVisitor visitor)
        => visitor.VisitImage(this);
}
