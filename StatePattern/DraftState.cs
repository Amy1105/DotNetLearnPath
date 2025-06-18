
// 具体状态：草稿
public class DraftState : IDocumentState
{
    public void Create(Document document)
    {
        Console.WriteLine("文档已处于草稿状态");
    }

    public void Review(Document document)
    {
        Console.WriteLine("文档从草稿进入审核中");
        document.ChangeState(new ReviewState());
    }

    public void Publish(Document document)
    {
        Console.WriteLine("错误：草稿状态不能直接发布");
    }

    public void Reject(Document document)
    {
        Console.WriteLine("错误：草稿状态不能被拒绝");
    }

    public string GetStatus() => "草稿";
}
