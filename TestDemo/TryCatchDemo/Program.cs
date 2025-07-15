// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string s = "123";

if(double.TryParse(s,out double d))
{
    Console.WriteLine(d);
}
else
{
    Console.WriteLine($"{s}无法转换成double类型");
}



try
{
   var dd= Convert.ToDouble(s);
}
catch(Exception e)
{
    Console.WriteLine($"{s}无法转换成double类型;"+e.Message);
}
