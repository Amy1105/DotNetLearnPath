
/// <summary>
/// 具体命令：音响打开并设置CD命令
/// </summary>
public class StereoOnWithCDCommand : ICommand
{
    private Stereo stereo;

    public StereoOnWithCDCommand(Stereo stereo)
    {
        this.stereo = stereo;
    }

    public void Execute()
    {
        stereo.On();
        stereo.SetCD();
        stereo.SetVolume(11);
    }

    public void Undo()
    {
        stereo.Off();
    }
}
