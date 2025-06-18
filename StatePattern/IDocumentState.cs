
/// <summary>
/// 状态接口
/// </summary>
public interface IDocumentState
{
    void Create(Document document);
    void Review(Document document);
    void Publish(Document document);
    void Reject(Document document);
    string GetStatus();
}
