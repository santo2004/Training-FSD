using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo1
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Category { get; set; }

        static List<Supplier> suppliers = new List<Supplier>()
        {
            new Supplier(){SupplierId = 1,SupplierName="iball",Category="iball"},
            new Supplier(){SupplierId = 2,SupplierName="Hp",Category="Hp"},
            new Supplier(){SupplierId = 3,SupplierName="DOMS",Category="Stationary"},
            new Supplier(){SupplierId = 3,SupplierName="cooling fan",Category="Gamerz1"},
        };

        Product product = new Product();
        List<Product> products = new List<Product>();

        public void Demo()
        {
            products = product.GetAllProducts();

            var uniqueProducts = products.Select(p => p.Category).Distinct();
            foreach (var cat in uniqueProducts)
                Console.WriteLine($"{cat}");

            var commonCategories = products.Select(p => p.Category)
                                           .Intersect(suppliers.Select(s => s.Category));
            foreach (var item in commonCategories)
                Console.WriteLine($"{item}");

            var allNames = products.Select(p => p.Category)
                                   .Union(suppliers.Select(s => s.Category));
            foreach (var item in allNames)
                Console.WriteLine($"{item}");

            var productsOnlyCategories = products.Select(p => p.Category)
                                                 .Except(suppliers.Select(s => s.Category));
            foreach (var item in productsOnlyCategories)
                Console.WriteLine(item);

            var skipFirst2 = products.Skip(2);
            var skipwhilePriceis6000 = products.SkipWhile(p => p.Price < 1300);
            foreach (var item in skipFirst2)
                Console.WriteLine($"{item.Name}");

            foreach (var item in skipwhilePriceis6000)
                Console.WriteLine($"{item.Name}");

            var first2products = products.Take(2);
            var takewhileCheapPrice = products.TakeWhile(p => p.Price < 2000);
            foreach (var item in first2products)
                Console.WriteLine(item.Name);
            foreach (var item in takewhileCheapPrice)
                Console.WriteLine(item.Name);

            var firstExpensiveProduct = products.FirstOrDefault(p => p.Price > 10000);
            var firstCheapProduct = products.First(p => p.Price < 500);
            Console.WriteLine($"FirstExpensiveProduct= {firstExpensiveProduct.Name}");
            Console.WriteLine($"First Cheap Product = {firstCheapProduct.Name}");

            var onlyProjector = products.Single(p => p.Name == "projector");
            var onlyScanner = products.SingleOrDefault(p => p.Name == "Scanner");
            Console.WriteLine($"Only Projector = {onlyProjector.Name}");

            bool anyStationary = products.Any(p => p.Category == "Stationary");
            bool allConstly = products.All(p => p.Price > 500);
            Console.WriteLine($"Any Stationary = {anyStationary}");
            Console.WriteLine($"All products >500 = {allConstly}");

            int totalPrice = products.Sum(p => p.Price);
            int totalCount = products.Count();
            int maxPrice = products.Max(p => p.Price);
            int minPrice = products.Min(p => p.Price);
            double avgPrice = products.Average(p => p.Price);
            Console.WriteLine($"TotalPrice = {totalPrice}");
            Console.WriteLine($"Total Product Count = {totalCount}");
            Console.WriteLine($"Maximum price = {maxPrice}");
            Console.WriteLine($"Minimum Price = {minPrice}");
            Console.WriteLine($"Average Price = {avgPrice}");

            var result = from p in products
                         join s in suppliers on p.Category equals s.Category
                         select new { ProductName = p.Name, Supplier = s.SupplierName };
            foreach (var item in result)
                Console.WriteLine($"{item.ProductName} \t {item.Supplier}");

            var leftJoinResult = from s in suppliers
                                 join p in products on s.Category equals p.Category into prodGroup
                                 from pg in prodGroup.DefaultIfEmpty()
                                 select new
                                 {
                                     supplier = s.SupplierName,
                                     product = pg != null ? pg.Name : "No Products"
                                 };
            foreach (var item in leftJoinResult)
                Console.WriteLine($"{item.supplier} supplies {item.product}");

            var groupjoinResult = from s in suppliers
                                  join p in products on s.Category equals p.Category into prodGroup
                                  select new { supplier = s.SupplierName, products = prodGroup };
            foreach (var group in groupjoinResult)
            {
                Console.WriteLine($"{group.supplier} supplies:");
                foreach (var p in group.products)
                    Console.WriteLine($"- {p.Name}");
            }

            var customJoin = from p in products
                             join s in suppliers on p.Category equals s.Category
                             where p.Price > 5000
                             select new { Message = $"{s.SupplierName} provides {p.Name} for {p.Price}" };
            foreach (var item in customJoin)
                Console.WriteLine(item.Message);

            var filteredResult = from p in products
                                 join s in suppliers on p.Category equals s.Category
                                 where p.Category == "Stationary" && p.Price < 5000
                                 select new { Product = p.Name, Price = p.Price, Supplier = s.SupplierName };
            foreach (var item in filteredResult)
                Console.WriteLine($"{item.Product} ({item.Price}) - supplied by {item.Supplier}");
        }
    }
}
