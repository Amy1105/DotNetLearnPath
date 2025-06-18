
/// <summary>
/// 具体子类：刺客
/// </summary>
public class AssassinCreator : CharacterCreator
{
    protected override void SelectRace()
    {
        Console.WriteLine("选择兽人种族");
    }

    protected override void AssignClass()
    {
        Console.WriteLine("职业：刺客");
    }

    protected override void EquipStartingGear()
    {
        Console.WriteLine("装备匕首和轻甲");
    }
}
