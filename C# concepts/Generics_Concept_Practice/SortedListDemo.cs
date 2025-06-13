using System;
using System.Collections.Generic;

public class SortedListDemo
{
    public static void Run()
    {
        Console.WriteLine("SortedList Demo:");
        SortedList<int, string> data = new SortedList<int, string>
        {
            { 3, "C" },
            { 1, "A" },
            { 2, "B" }
        };

        foreach (var item in data)
            Console.WriteLine($"{item.Key}: {item.Value}");
        Console.WriteLine();
    }
}
