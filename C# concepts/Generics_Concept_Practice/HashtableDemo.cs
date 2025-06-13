using System;
using System.Collections;

public class HashtableDemo
{
    public static void Run()
    {
        Console.WriteLine("Non-Generic Hashtable Demo:");

        Hashtable hashtable = new Hashtable();
        hashtable.Add(1, "One");
        hashtable.Add("Two", 2);
        hashtable.Add(3.0, "Three");

        Console.WriteLine("Hashtable contents:");
        foreach (DictionaryEntry entry in hashtable)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }

        // Accessing with casting
        string one = (string)hashtable[1];
        int two = (int)hashtable["Two"];
        string three = (string)hashtable[3.0];

        Console.WriteLine($"\nAccessed with casting:");
        Console.WriteLine($"1 = {one}, 'Two' = {two}, 3.0 = {three}\n");
    }
}
