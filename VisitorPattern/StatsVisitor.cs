/// <summary>
/// 文档元素接口（接受访问者）
/// </summary>
public class StatsVisitor : IDocumentVisitor
{
    public int TotalWords { get; private set; }
    public int TotalImages { get; private set; }
    public int TotalTables { get; private set; }

    public void VisitText(TextElement text)
        => TotalWords += text.WordCount;

    public void VisitImage(ImageElement image)
        => TotalImages++;

    public void VisitTable(TableElement table)
        => TotalTables++;
}
