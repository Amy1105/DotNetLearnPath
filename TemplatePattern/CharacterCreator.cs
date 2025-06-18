
/// <summary>
/// 抽象类：角色创建模板
/// </summary>
public abstract class CharacterCreator
{
    // 模板方法：定义角色创建的整体流程
    public void CreateCharacter()
    {
        SelectRace();
        AssignClass();
        SetAttributes();
        EquipStartingGear();
        Console.WriteLine("角色创建完成！");
    }

    // 抽象方法：子类必须实现
    protected abstract void SelectRace();
    protected abstract void AssignClass();

    // 具体方法：子类可以直接使用
    protected void SetAttributes()
    {
        Console.WriteLine("分配基础属性点");
    }

    // 钩子方法：子类可以选择性重写
    protected virtual void EquipStartingGear()
    {
        Console.WriteLine("装备初始武器和防具");
    }
}
