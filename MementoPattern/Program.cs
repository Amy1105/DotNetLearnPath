//备忘录模式（Memento Pattern）保存一个对象的某个状态，以便在适当的时候恢复对象，备忘录模式属于行为型模式。
//备忘录模式允许在不破坏封装性的前提下，捕获和恢复对象的内部状态。


//备忘录模式包含以下几个主要角色：

//备忘录（Memento）：负责存储原发器对象的内部状态。备忘录可以保持原发器的状态的一部分或全部信息。

//原发器（Originator）：创建一个备忘录对象，并且可以使用备忘录对象恢复自身的内部状态。原发器通常会在需要保存状态的时候创建备忘录对象，并在需要恢复状态的时候使用备忘录对象。

//负责人（Caretaker）：负责保存备忘录对象，但是不对备忘录对象进行操作或检查。负责人只能将备忘录传递给其他对象。

        TextEditor editor = new TextEditor();
        Caretaker caretaker = new Caretaker();

        // 编辑文本并保存状态
        editor.Content = "Hello";
        editor.CursorPosition = 5;
        caretaker.SaveState(editor);
        editor.Display();

        // 继续编辑并保存状态
        editor.Content += " World";
        editor.CursorPosition = 11;
        caretaker.SaveState(editor);
        editor.Display();

        // 修改内容但不保存
        editor.Content += "!";
        editor.CursorPosition = 12;
        editor.Display();

        // 撤销操作
        Console.WriteLine("\n执行撤销...");
        caretaker.Undo(editor);
        editor.Display();

        // 再次撤销
        Console.WriteLine("\n执行撤销...");
        caretaker.Undo(editor);
        editor.Display();

        // 尝试再次撤销（已无历史状态）
        Console.WriteLine("\n执行撤销...");
        caretaker.Undo(editor);


//需要注意的是，备忘录模式可能会消耗较多的内存，特别是在频繁保存状态的情况下。在这种情况下，可以考虑结合使用其他设计模式（如原型模式）来优化内存使用。