using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 43, 657, 68, 345, 634 };

            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;
            foreach (var item in evenNumbers)
                Console.WriteLine(item);

            var evenNumbers1 = numbers.Where(n => n % 2 == 0);
            foreach (var item in evenNumbers1)
                Console.WriteLine(item);

            IList mixedList = new ArrayList();
            mixedList.Add(10);
            mixedList.Add(20);
            mixedList.Add("Fransy");
            mixedList.Add("Test");
            mixedList.Add(new Product()
            { ProductId = 1, Name = "Test Product", Description = "Test DEscription", Price = 234 });

            var intList1 = mixedList.OfType<int>();
            var stringList1 = mixedList.OfType<string>();
            var productList1 = mixedList.OfType<Product>();

            foreach (var i in intList1)
                Console.WriteLine(i);

            foreach (var i in stringList1)
                Console.WriteLine(i);

            foreach (var i in productList1)
                Console.WriteLine($"{i.ProductId}\t{i.Name}\t{i.Description}\t{i.Price}");

            Product product = new Product();
            product.Demo();

            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> stringList = new List<string>() { null, "One", "Three", "Two", "Five", "Four" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine($"First Element: {intList.First()}");
            Console.WriteLine($"First Even Element: {intList.First(i => i % 2 == 0)}");
            Console.WriteLine($"First String Element: {stringList.First()}");

            Console.WriteLine($"FirstOrDefault: {intList.FirstOrDefault()}");
            Console.WriteLine($"First Even (OrDefault): {intList.FirstOrDefault(i => i % 2 == 0)}");
            Console.WriteLine($"FirstOrDefault String: {stringList.FirstOrDefault()}");
            Console.WriteLine($"Empty List FirstOrDefault: {emptyList.FirstOrDefault()}");

            Console.WriteLine($"Last: {intList.Last()}");
            Console.WriteLine($"Last Even: {intList.Last(i => i % 2 == 0)}");
            Console.WriteLine($"Last String: {stringList.Last()}");

            Supplier supplier = new Supplier();
            supplier.Demo();
            Console.ReadLine();
        }
    }
}
