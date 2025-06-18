
/// <summary>
/// 文档元素接口（接受访问者）
/// </summary>
public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}
