


// 创建一个价格为1000的订单
Order order = new Order(1000, new RegularMemberStrategy());

        Console.WriteLine("原价：" + order.TotalPrice);

        // 普通会员价格
        Console.WriteLine("普通会员最终价格：" + order.CalculateFinalPrice());
        Console.WriteLine();

        // 改为银卡会员策略
        order.SetDiscountStrategy(new SilverMemberStrategy());
        Console.WriteLine("银卡会员最终价格：" + order.CalculateFinalPrice());
        Console.WriteLine();

        // 改为金卡会员策略
        order.SetDiscountStrategy(new GoldMemberStrategy());
        Console.WriteLine("金卡会员最终价格：" + order.CalculateFinalPrice());
