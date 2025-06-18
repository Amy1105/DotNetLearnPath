
/// <summary>
/// 访问者接口（定义对不同元素的操作）
/// </summary>
public class TableElement : IDocumentElement
{
    public int Rows { get; set; }
    public int Columns { get; set; }

    public void Accept(IDocumentVisitor visitor)
        => visitor.VisitTable(this);
}
