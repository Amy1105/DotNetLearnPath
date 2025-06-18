


/// <summary>
/// 气象站（主题）:维护着观察者列表，并在状态发生改变时通知观察者
/// </summary>
public class WeatherStation : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private WeatherData weatherData = new WeatherData();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(weatherData);
        }
    }

    // 当天气数据变化时调用此方法
    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    // 设置新的天气测量数据
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        weatherData.Temperature = temperature;
        weatherData.Humidity = humidity;
        weatherData.Pressure = pressure;
        MeasurementsChanged();
    }
}
