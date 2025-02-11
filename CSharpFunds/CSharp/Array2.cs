using System.Collections;

var a = new ArrayList
{
    "Hello",
    "Bye",
    "Apple",
    "Peach"
};

Console.WriteLine(a[1]);
Console.WriteLine("------------------------");

foreach (var item in a)
{
    Console.WriteLine(item);
}

Console.WriteLine("------------------------");

Console.WriteLine(a.Contains("Apple"));
Console.WriteLine(a.Contains("Banana"));
Console.WriteLine("------------------------");

Console.WriteLine("After sorting:");
a.Sort();
foreach (var item in a)
{
    Console.WriteLine(item);
}