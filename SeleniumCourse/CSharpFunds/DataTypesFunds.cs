namespace SeleniumCourse.CSharpFunds;

class Program
{
    private static void Main()
    {
        Console.WriteLine("Data Types Fundamentals");
        int a = 4;
        Console.WriteLine("Value of a: " + a);
        
        String name = "Selenium";
        Console.WriteLine("Value of name: " + name);
        Console.WriteLine("------------------------");
        
        Console.WriteLine($"Value of name: {name}");
        Console.WriteLine("------------------------");
        
        var age = 30;
        Console.WriteLine("Age is: " + age);
        // age = "Hello"; // Error
        
        Console.WriteLine("------------------------");
        
        // Dynamic Data Type gives flexibility to change the data type
        dynamic height = 13.2;
        Console.WriteLine("Height is: " + height);
        height = "Hello"; // No Error
        Console.WriteLine("Height is: " + height);
        Console.WriteLine("------------------------");
        
        // Call a method from another class
        Methods obj = new Methods();
        obj.getData();
    }
}