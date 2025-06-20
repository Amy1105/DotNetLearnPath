using System;
using System.Collections.Generic;

// 产品类：表示复杂对象
public class Car
{
    public string Model { get; set; }
    public string Engine { get; set; }
    public int Wheels { get; set; }
    public string Color { get; set; }
    public List<string> Features { get; set; } = new List<string>();

    public void ShowInfo()
    {
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Engine: {Engine}");
        Console.WriteLine($"Wheels: {Wheels}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine("Features:");
        foreach (var feature in Features)
        {
            Console.WriteLine($"  - {feature}");
        }
    }
}

// 建造者接口：定义构建步骤
public interface ICarBuilder
{
    void SetModel();
    void SetEngine();
    void SetWheels();
    void SetColor();
    void AddFeatures();
    Car GetCar();
}

// 具体建造者：构建豪华轿车
public class LuxuryCarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void SetModel()
    {
        _car.Model = "Mercedes-Benz S-Class";
    }

    public void SetEngine()
    {
        _car.Engine = "4.0L V8 Biturbo";
    }

    public void SetWheels()
    {
        _car.Wheels = 4;
    }

    public void SetColor()
    {
        _car.Color = "Black";
    }

    public void AddFeatures()
    {
        _car.Features.Add("Leather Seats");
        _car.Features.Add("Sunroof");
        _car.Features.Add("Navigation System");
        _car.Features.Add("Adaptive Cruise Control");
    }

    public Car GetCar()
    {
        return _car;
    }
}

// 具体建造者：构建经济型轿车
public class EconomyCarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void SetModel()
    {
        _car.Model = "Toyota Corolla";
    }

    public void SetEngine()
    {
        _car.Engine = "1.8L 4-Cylinder";
    }

    public void SetWheels()
    {
        _car.Wheels = 4;
    }

    public void SetColor()
    {
        _car.Color = "White";
    }

    public void AddFeatures()
    {
        _car.Features.Add("Cloth Seats");
        _car.Features.Add("Bluetooth");
        _car.Features.Add("Backup Camera");
    }

    public Car GetCar()
    {
        return _car;
    }
}

// 指挥者：控制构建过程
public class CarDirector
{
    private ICarBuilder _builder;

    public CarDirector(ICarBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructCar()
    {
        _builder.SetModel();
        _builder.SetEngine();
        _builder.SetWheels();
        _builder.SetColor();
        _builder.AddFeatures();
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 构建豪华轿车
        ICarBuilder luxuryBuilder = new LuxuryCarBuilder();
        CarDirector luxuryDirector = new CarDirector(luxuryBuilder);
        luxuryDirector.ConstructCar();
        Car luxuryCar = luxuryBuilder.GetCar();

        Console.WriteLine("Luxury Car:");
        luxuryCar.ShowInfo();

        Console.WriteLine("\n------------------------\n");

        // 构建经济型轿车
        ICarBuilder economyBuilder = new EconomyCarBuilder();
        CarDirector economyDirector = new CarDirector(economyBuilder);
        economyDirector.ConstructCar();
        Car economyCar = economyBuilder.GetCar();

        Console.WriteLine("Economy Car:");
        economyCar.ShowInfo();
    }
}