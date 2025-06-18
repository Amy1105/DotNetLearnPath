
/// <summary>
/// 具体命令：音响关闭命令
/// </summary>
public class StereoOffCommand : ICommand
{
    private Stereo stereo;

    public StereoOffCommand(Stereo stereo)
    {
        this.stereo = stereo;
    }

    public void Execute()
    {
        stereo.Off();
    }

    public void Undo()
    {
        // 简化实现，实际应恢复到之前的状态
        stereo.On();
        stereo.SetCD();
        stereo.SetVolume(11);
    }
}
