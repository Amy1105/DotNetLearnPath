
/// <summary>
/// 具体子类：战士
/// </summary>
public class WarriorCreator : CharacterCreator
{
    protected override void SelectRace()
    {
        Console.WriteLine("选择人类种族");
    }

    protected override void AssignClass()
    {
        Console.WriteLine("职业：战士");
    }

    protected override void EquipStartingGear()
    {
        Console.WriteLine("装备战剑和盾牌");
    }
}
