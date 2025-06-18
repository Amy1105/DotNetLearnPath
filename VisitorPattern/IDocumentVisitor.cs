// 文档元素接口（接受访问者）
// 访问者接口（定义对不同元素的操作）
public interface IDocumentVisitor
{
    void VisitText(TextElement text);
    void VisitImage(ImageElement image);
    void VisitTable(TableElement table);
}
