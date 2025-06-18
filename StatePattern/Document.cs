
/// <summary>
/// 上下文：文档类
/// </summary>
public class Document
{
    private IDocumentState currentState;

    public Document()
    {
        currentState = new DraftState();
        Console.WriteLine("文档已创建，初始状态：草稿");
    }

    public void ChangeState(IDocumentState state)
    {
        currentState = state;
    }

    public void Create()
    {
        currentState.Create(this);
    }

    public void Review()
    {
        currentState.Review(this);
    }

    public void Publish()
    {
        currentState.Publish(this);
    }

    public void Reject()
    {
        currentState.Reject(this);
    }

    public string GetCurrentStatus()
    {
        return currentState.GetStatus();
    }
}
