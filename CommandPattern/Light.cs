
/// <summary>
/// 接收者：灯光设备
/// </summary>
public class Light
{
    private string location;
    private bool isOn;

    public Light(string location)
    {
        this.location = location;
        isOn = false;
    }

    public void On()
    {
        isOn = true;
        Console.WriteLine($"{location} 灯光已打开");
    }

    public void Off()
    {
        isOn = false;
        Console.WriteLine($"{location} 灯光已关闭");
    }
}
