using System;
using System.Collections.Generic;

public class SortedSetDemo
{
    public static void Run()
    {
        Console.WriteLine("SortedSet Demo:");
        SortedSet<int> numbers = new SortedSet<int> { 5, 3, 1, 4, 2, 2 };

        foreach (var num in numbers)
            Console.WriteLine(num);
        Console.WriteLine();
    }
}
