


//抽象父类（Abstract Class）：定义了模板方法和一些抽象方法或具体方法。
//具体子类（Concrete Classes）：继承自抽象父类，并实现抽象方法。
//钩子方法（Hook Method）（可选）：在抽象父类中定义，可以被子类重写，以影响模板方法的行为。
//客户端（Client）（可选）：使用抽象父类和具体子类，无需关心模板方法的细节。


        Console.WriteLine("=== 创建战士 ===");
        CharacterCreator warrior = new WarriorCreator();
        warrior.CreateCharacter();

        Console.WriteLine("\n=== 创建法师 ===");
        CharacterCreator mage = new MageCreator();
        mage.CreateCharacter();

        Console.WriteLine("\n=== 创建刺客 ===");
        CharacterCreator assassin = new AssassinCreator();
        assassin.CreateCharacter();
