

/// <summary>
/// 具体命令：灯光关闭命令
/// </summary>
public class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.Off();
    }

    public void Undo()
    {
        light.On();
    }
}
