using System;
using System.Collections;

public class ArrayListDemo
{
    public static void Run()
    {
        Console.WriteLine("Non-Generic ArrayList Demo:");

        ArrayList arrayList = new ArrayList();
        arrayList.Add(10);           // int
        arrayList.Add("Hello");      // string
        arrayList.Add(3.14);         // double

        Console.WriteLine("ArrayList contents:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        // Accessing with casting
        int num = (int)arrayList[0];
        string text = (string)arrayList[1];
        double pi = (double)arrayList[2];

        Console.WriteLine($"\nAccessed with casting:");
        Console.WriteLine($"Integer: {num}, String: {text}, Double: {pi}\n");
    }
}
