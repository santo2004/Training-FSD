using System;
using System.Collections.Generic;

public class DictionaryDemo
{
    public static void Run()
    {
        Console.WriteLine("Dictionary Demo:");
        Dictionary<int, string> students = new Dictionary<int, string>
        {
            { 1, "John" },
            { 2, "Jane" }
        };

        foreach (var s in students)
            Console.WriteLine($"ID: {s.Key}, Name: {s.Value}");
        Console.WriteLine();
    }
}
