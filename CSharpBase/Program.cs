// See https://aka.ms/new-console-template for more information

//try
//{
//    object result = null;
//    double v = Convert.ToDouble(result);
//}
//catch (Exception)
//{

//	throw;
//}


var combinations =
    from a in new[] { true, false }
    from b in new[] { true, false }
    from c in new[] { true, false }
    select new { a, b, c };

foreach (var combo in combinations)
{
    if (combo.a || combo.b && combo.c)
    {
        Console.WriteLine($"组合: {combo.a}, {combo.b}, {combo.c}");
    }
}


Console.WriteLine("Hello, World!");
