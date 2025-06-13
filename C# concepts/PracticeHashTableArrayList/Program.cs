using System;
using System.Collections;
using System.Collections.Generic;

namespace PracticeHashTableArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create Hashtable with 5 records and display them
            Hashtable studentTable = new Hashtable();
            studentTable.Add(101, "Ashik");
            studentTable.Add(102, "Jeffrey");
            studentTable.Add(103, "Nithin");
            studentTable.Add(104, "Roger");
            studentTable.Add(105, "Santo");

            Console.WriteLine("1. Student Records in Hashtable:");
            foreach (DictionaryEntry entry in studentTable)
            {
                Console.WriteLine($"Roll No: {entry.Key}, Name: {entry.Value}");
            }

            // 2. Create ArrayList and add 5 product names
            ArrayList productList = new ArrayList { "Laptop", "Mouse", "Keyboard", "Monitor", "Printer" };

            Console.WriteLine("\n2. Products in ArrayList:");
            foreach (var item in productList)
            {
                Console.WriteLine(item);
            }

            // 3. Search and update key in hashtable
            int searchKey = 103;
            if (studentTable.ContainsKey(searchKey))
            {
                studentTable[searchKey] = "Nitish";
                Console.WriteLine($"\n3. Updated student with Roll No {searchKey}: {studentTable[searchKey]}");
            }

            // 4. Remove item at index 2 and another by value from ArrayList
            if (productList.Count > 2)
                productList.RemoveAt(2); // remove "Keyboard"

            productList.Remove("Monitor");

            Console.WriteLine("\n4. ArrayList after removals:");
            foreach (var item in productList)
            {
                Console.WriteLine(item);
            }

            // 5. Count and clear hashtable
            Console.WriteLine($"\n5. Total entries in Hashtable: {studentTable.Count}");
            studentTable.Clear();
            Console.WriteLine("Hashtable cleared.");

            // 6. Sort and reverse an ArrayList of numbers
            ArrayList numberList = new ArrayList { 42, 7, 19, 85, 23 };
            numberList.Sort();
            Console.WriteLine("\n6. Sorted number list:");
            foreach (var num in numberList)
            {
                Console.WriteLine(num);
            }

            numberList.Reverse();
            Console.WriteLine("Reversed number list:");
            foreach (var num in numberList)
            {
                Console.WriteLine(num);
            }

            // 7. Add duplicate key to hashtable and handle exception
            Hashtable ht = new Hashtable();
            ht.Add(1, "First");
            try
            {
                ht.Add(1, "Duplicate");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n7. Exception: {ex.Message}");
            }

            // 8. Insert product at index 1
            productList.Insert(1, "Tablet");
            Console.WriteLine("\n8. Updated product list after inserting at index 1:");
            foreach (var item in productList)
            {
                Console.WriteLine(item);
            }

            // 9. Print keys and values of hashtable
            ht.Add(2, "Second");
            ht.Add(3, "Third");

            Console.WriteLine("\n9. Hashtable Keys:");
            foreach (var key in ht.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("Hashtable Values:");
            foreach (var val in ht.Values)
            {
                Console.WriteLine(val);
            }

            Console.ReadKey();
        }
    }
}