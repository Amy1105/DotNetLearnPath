

/// <summary>
/// 手机显示（观察者）
/// </summary>
public class PhoneDisplay : IObserver
{
    private  WeatherData weatherData;

    public void Update(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        Display();
    }

    private void Display()
    {
        Console.WriteLine("手机显示:");
        Console.WriteLine($"温度: {weatherData.Temperature}°C");
        Console.WriteLine($"湿度: {weatherData.Humidity}%");
        Console.WriteLine($"气压: {weatherData.Pressure} hPa");
        Console.WriteLine("-------------------");
    }
}
