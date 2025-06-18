
/// <summary>
/// 接收者：音响设备
/// </summary>
public class Stereo
{
    private string location;
    private int volume;

    public Stereo(string location)
    {
        this.location = location;
        volume = 5;
    }

    public void On()
    {
        Console.WriteLine($"{location} 音响已打开");
    }

    public void Off()
    {
        Console.WriteLine($"{location} 音响已关闭");
    }

    public void SetCD()
    {
        Console.WriteLine($"{location} 音响设置为CD模式");
    }

    public void SetVolume(int volume)
    {
        this.volume = volume;
        Console.WriteLine($"{location} 音响音量设置为 {volume}");
    }
}
