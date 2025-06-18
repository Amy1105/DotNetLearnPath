

/// <summary>
/// 网页显示（观察者）
/// </summary>
public class WebDisplay : IObserver
{
    private WeatherData weatherData;

    public void Update(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        Display();
    }

    private void Display()
    {
        Console.WriteLine("网页显示:");
        Console.WriteLine($"当前温度: {weatherData.Temperature}°C");
        Console.WriteLine($"相对湿度: {weatherData.Humidity}%");
        Console.WriteLine($"大气压力: {weatherData.Pressure} hPa");
        Console.WriteLine("===================");
    }
}
