using System;
using System.Collections.Generic;

// 享元接口：定义可共享的状态
public interface ICharacter
{
    void Display(int pointSize);
}

// 具体享元类：表示字符对象
public class Character : ICharacter
{
    private readonly char _symbol;  // 内部状态（不可变，共享）
    private readonly ConsoleColor _color;  // 内部状态

    public Character(char symbol, ConsoleColor color)
    {
        _symbol = symbol;
        _color = color;
    }

    // 外部状态通过参数传入
    public void Display(int pointSize)
    {
        Console.ForegroundColor = _color;
        Console.WriteLine($"Character: {_symbol}, Size: {pointSize}pt");
        Console.ResetColor();
    }
}

// 享元工厂：负责创建和管理享元对象
public class CharacterFactory
{
    private readonly Dictionary<string, ICharacter> _characters = new Dictionary<string, ICharacter>();

    // 获取享元对象
    public ICharacter GetCharacter(char symbol, ConsoleColor color)
    {
        string key = $"{symbol}_{color}";

        if (!_characters.ContainsKey(key))
        {
            _characters[key] = new Character(symbol, color);
            Console.WriteLine($"Creating character: {symbol} in {color}");
        }

        return _characters[key];
    }

    // 获取当前享元对象数量
    public int GetCharacterCount()
    {
        return _characters.Count;
    }
}

// 客户端代码
class Program
{
    static void Main()
    {
        // 创建享元工厂
        CharacterFactory factory = new CharacterFactory();

        // 创建并展示字符（共享对象）
        ICharacter characterA = factory.GetCharacter('A', ConsoleColor.Red);
        characterA.Display(12);

        ICharacter characterB = factory.GetCharacter('B', ConsoleColor.Green);
        characterB.Display(14);

        // 尝试重复创建相同的字符（应该复用已有对象）
        ICharacter anotherA = factory.GetCharacter('A', ConsoleColor.Red);
        anotherA.Display(16);

        Console.WriteLine($"Total characters created: {factory.GetCharacterCount()}");
    }
}