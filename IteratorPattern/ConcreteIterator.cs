using System.Collections;

/// <summary>
/// 迭代器接口 - 继承自IEnumerator
/// </summary>
public class ConcreteIterator : IEnumerator
{
    private readonly ArrayList _items;
    private int _position = -1; // 初始位置设为-1

    public ConcreteIterator(ArrayList items)
    {
        _items = items;
    }

    public object Current
    {
        get
        {
            if (_position < 0 || _position >= _items.Count)
                throw new InvalidOperationException();
            return _items[_position];
        }
    }

    public bool MoveNext()
    {
        _position++;
        return _position < _items.Count;
    }

    public void Reset()
    {
        _position = -1;
    }
}
