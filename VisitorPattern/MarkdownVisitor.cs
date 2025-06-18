using System.Text;

/// <summary>
/// 文档元素接口（接受访问者）
/// </summary>
public class MarkdownVisitor : IDocumentVisitor
{
    private StringBuilder _output = new StringBuilder();

    public string GetResult() => _output.ToString();

    public void VisitText(TextElement text)
        => _output.AppendLine($"# {text.Content}\n");

    public void VisitImage(ImageElement image)
        => _output.AppendLine($"![image]({image.FilePath})");

    public void VisitTable(TableElement table)
        => _output.AppendLine($"| {'|'.Repeat(table.Columns)}\n{'-'.Repeat(table.Columns * 2 + 1)}");
}
