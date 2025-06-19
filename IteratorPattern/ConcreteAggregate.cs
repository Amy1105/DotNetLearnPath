
using System.Collections;


/// <summary>
/// 聚合接口 - 继承自IEnumerable
/// </summary>
public class ConcreteAggregate : IEnumerable
{
    private readonly ArrayList _items = new ArrayList();

    public int Count => _items.Count;

    public object this[int index]
    {
        get => _items[index];
        set => _items.Add(value);
    }

    public IEnumerator GetEnumerator()
    {
        return new ConcreteIterator(_items);
    }
}

