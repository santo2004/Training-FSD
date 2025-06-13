using System;
using System.Collections.Generic;

public class ListDemo
{
    public static void Run()
    {
        Console.WriteLine("List Demo:");
        List<string> names = new List<string> { "Alice", "Bob" };
        names.Add("Charlie");

        foreach (var name in names)
            Console.WriteLine(name);
        Console.WriteLine();
    }
}
