
// 具体状态：已发布
public class PublishedState : IDocumentState
{
    public void Create(Document document)
    {
        Console.WriteLine("错误：已发布的文档不能创建");
    }

    public void Review(Document document)
    {
        Console.WriteLine("已发布的文档需要先撤回才能审核");
    }

    public void Publish(Document document)
    {
        Console.WriteLine("文档已发布");
    }

    public void Reject(Document document)
    {
        Console.WriteLine("错误：已发布的文档不能被拒绝");
    }

    public string GetStatus() => "已发布";
}
