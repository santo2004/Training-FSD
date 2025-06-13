using System;
using System.Collections.Generic;

public class StackDemo
{
    public static void Run()
    {
        Console.WriteLine("Stack Demo:");
        Stack<string> history = new Stack<string>();
        history.Push("Page1");
        history.Push("Page2");

        while (history.Count > 0)
            Console.WriteLine("Back to " + history.Pop());
        Console.WriteLine();
    }
}
