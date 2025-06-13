using System;
using System.Collections.Generic;

public class LinkedListDemo
{
    public static void Run()
    {
        Console.WriteLine("LinkedList Demo:");
        LinkedList<string> items = new LinkedList<string>();
        items.AddLast("First");
        items.AddLast("Second");
        items.AddFirst("Zero");

        foreach (var item in items)
            Console.WriteLine(item);
        Console.WriteLine();
    }
}
