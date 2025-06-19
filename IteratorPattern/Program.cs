//迭代器模式是一种行为设计模式，它提供了一种方法来顺序访问一个聚合对象中的各个元素，而又不暴露该对象的内部表示

//IEnumerable 和 IEnumerator 是两个核心接口，它们共同构成了迭代器模式的基础


using System.Collections;

ConcreteAggregate collection = new ConcreteAggregate();
collection[0] = "项目1";
collection[1] = "项目2";
collection[2] = "项目3";
collection[3] = "项目4";

// 使用foreach语法糖
Console.WriteLine("使用foreach遍历:");
foreach (var item in collection)
{
    Console.WriteLine(item);
}

// 手动使用迭代器
Console.WriteLine("\n手动使用迭代器遍历:");
IEnumerator iterator = collection.GetEnumerator();
while (iterator.MoveNext())
{
    Console.WriteLine(iterator.Current);
}