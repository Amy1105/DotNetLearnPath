//命令模式（Command Pattern）是一种数据驱动的设计模式，它属于行为型模式
//将一个请求封装为一个对象，从而使你可以用不同的请求对客户进行参数化，对请求排队或记录请求日志，以及支持可撤销的操作。


//主要涉及到以下几个核心角色：

//命令（Command）:
//定义了执行操作的接口，通常包含一个 execute 方法，用于调用具体的操作。
//具体命令（ConcreteCommand）:

//实现了命令接口，负责执行具体的操作。它通常包含了对接收者的引用，通过调用接收者的方法来完成请求的处理。
//接收者（Receiver）:
//知道如何执行与请求相关的操作，实际执行命令的对象。
//调用者/请求者（Invoker）:

//发送命令的对象，它包含了一个命令对象并能触发命令的执行。调用者并不直接处理请求，而是通过将请求传递给命令对象来实现。
//客户端（Client）:
//创建具体命令对象并设置其接收者，将命令对象交给调用者执行。


// 创建遥控器
RemoteControl remoteControl = new RemoteControl();

        // 创建家电设备
        Light livingRoomLight = new Light("客厅");
        Light kitchenLight = new Light("厨房");
        Stereo livingRoomStereo = new Stereo("客厅");

        // 创建命令
        LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
        LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);
        LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
        LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);
        StereoOnWithCDCommand stereoOn = new StereoOnWithCDCommand(livingRoomStereo);
        StereoOffCommand stereoOff = new StereoOffCommand(livingRoomStereo);

        // 设置遥控器插槽
        remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
        remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
        remoteControl.SetCommand(2, stereoOn, stereoOff);

        // 显示遥控器状态
        Console.WriteLine(remoteControl);

        // 使用遥控器
        remoteControl.PressOnButton(0);
        remoteControl.PressOffButton(0);
        remoteControl.PressOnButton(1);
        remoteControl.PressOffButton(1);
        remoteControl.PressOnButton(2);
        remoteControl.PressOffButton(2);

        // 测试撤销功能
        Console.WriteLine("\n-- 测试撤销功能 --");
        remoteControl.PressUndoButton();
        remoteControl.PressUndoButton();
        remoteControl.PressUndoButton();
