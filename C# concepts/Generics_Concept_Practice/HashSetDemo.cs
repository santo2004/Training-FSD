using System;
using System.Collections.Generic;

public class HashSetDemo
{
    public static void Run()
    {
        Console.WriteLine("HashSet Demo:");
        HashSet<string> cities = new HashSet<string> { "Delhi", "Mumbai", "Delhi" };

        foreach (var city in cities)
            Console.WriteLine(city);
        Console.WriteLine();
    }
}
