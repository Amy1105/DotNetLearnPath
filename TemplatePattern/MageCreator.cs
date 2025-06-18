
/// <summary>
/// 具体子类：法师
/// </summary>
public class MageCreator : CharacterCreator
{
    protected override void SelectRace()
    {
        Console.WriteLine("选择精灵种族");
    }

    protected override void AssignClass()
    {
        Console.WriteLine("职业：法师");
    }
}
