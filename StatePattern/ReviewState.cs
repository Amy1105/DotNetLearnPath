
/// <summary>
/// 具体状态：审核中
/// </summary>
public class ReviewState : IDocumentState
{
    public void Create(Document document)
    {
        Console.WriteLine("错误：审核中的文档不能创建");
    }

    public void Review(Document document)
    {
        Console.WriteLine("文档已在审核中");
    }

    public void Publish(Document document)
    {
        Console.WriteLine("文档从审核中发布成功");
        document.ChangeState(new PublishedState());
    }

    public void Reject(Document document)
    {
        Console.WriteLine("文档被拒绝，回到草稿状态");
        document.ChangeState(new DraftState());
    }

    public string GetStatus() => "审核中";
}
