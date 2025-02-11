//

string[] a = ["Selenium", "Java", "Python", "C#"];
int[] b = [1, 2, 3, 4, 5];

var a1 = new string[4];
a1[0] = "Selenium";
a1[1] = "Java";

Console.WriteLine(a[0]);
Console.WriteLine("------------------------");

for (var i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
    if(a[i] == "Python")
    {
        Console.WriteLine("Match found");
        break;
    }
}

Console.WriteLine("------------------------");