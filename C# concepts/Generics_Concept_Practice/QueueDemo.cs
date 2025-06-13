using System;
using System.Collections.Generic;

public class QueueDemo
{
    public static void Run()
    {
        Console.WriteLine("Queue Demo:");
        Queue<string> orders = new Queue<string>();
        orders.Enqueue("Order1");
        orders.Enqueue("Order2");

        while (orders.Count > 0)
            Console.WriteLine("Processing " + orders.Dequeue());
        Console.WriteLine();
    }
}
