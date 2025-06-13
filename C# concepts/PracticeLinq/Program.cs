using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{ CustomerId =1, Name = "Ashik" , Age = 22, City = "Villupuram"},
                new Customer{ CustomerId =2, Name = "Jeffrey" , Age = 22, City = "Thoothukudi"},
                new Customer{ CustomerId =3, Name = "Nitish" , Age = 22, City = "Erode"},
                new Customer{ CustomerId =4, Name = "Roger" , Age = 22, City = "Karaikudi"},
                new Customer{ CustomerId =5, Name = "Shruthi" , Age = 21, City = "Satur"},
                new Customer{ CustomerId =6, Name = "Viji" , Age = 21, City = "Villupuram"}
            };

            List<Insurance> insurances = new List<Insurance>
            {
                new Insurance { PolicyId = 101, CustomerId = 1, PolicyType = "Health", PremiumAmount = 5000m, IsActive = true},
                new Insurance { PolicyId = 102, CustomerId = 1, PolicyType = "Auto", PremiumAmount = 3000m, IsActive = false},
                new Insurance { PolicyId = 103, CustomerId = 2, PolicyType = "Home", PremiumAmount = 4500m, IsActive = true},
                new Insurance { PolicyId = 104, CustomerId = 3, PolicyType = "Life", PremiumAmount = 7000m, IsActive = true},
                new Insurance { PolicyId = 105, CustomerId = 4, PolicyType = "Health", PremiumAmount = 3500m, IsActive = true},
                new Insurance { PolicyId = 106, CustomerId = 5, PolicyType = "Auto", PremiumAmount = 6000m, IsActive = false},
                new Insurance { PolicyId = 107, CustomerId = 6, PolicyType = "Life", PremiumAmount = 4000m, IsActive = true}
            };

            //1. Get all customers from "New York" or given city
            string city = "Villupuram";
            var customersFromCity = customers.Where(c => c.City == city).ToList();
            Console.WriteLine("\nCustomers from 'Villupuram': \n");
            foreach ( var cus in customersFromCity)
            {
                Console.WriteLine($"{cus.Name} \t {cus.Name} \t {cus.City}");
            }
            

            //2. Select all active insurance policies with premium over 4000
            var activeHighPremiumPolicies = insurances
                                            .Where(i => i.IsActive && i.PremiumAmount > 4000)
                                            .ToList();
            Console.WriteLine("\nActive Insurance Policies with Premium over 4000: \n");
            foreach (var act in activeHighPremiumPolicies)
            {
                Console.WriteLine($"{act.PolicyId} \t {act.CustomerId} \t {act.PremiumAmount}");
            }

            //3. List All CustomerName, their Policy type, and Premium Amount
            var customerPolicies = from c in customers
                                   join i in insurances on c.CustomerId equals i.CustomerId
                                   select new
                                   {
                                       c.Name,
                                       i.PolicyType,
                                       i.PremiumAmount
                                   };
            

            //4. Calculate Total Premium for Each PolicyType
            var totalPremiumByType = insurances
                                    .GroupBy(i => i.PolicyType)
                                    .Select(g => new
                                    {
                                        PolicyType = g.Key,
                                        TotalPremium = g.Sum(i => i.PremiumAmount)
                                    });

            //5. Display the First Customer Details from given city
            var firstCustomerDallas = customers
                                      .FirstOrDefault(c => c.City == "Erode");

            //6. Check if any policy is inactive
            bool anyInactivePolicy = insurances.Any(i => !i.IsActive);

            //7. Check if all policies have premium amount > 1000
            bool allPremiumsAbove1000 = insurances.All(i => i.PremiumAmount > 1000);

            //8. Display unique policy types
            var uniquePolicyTypes = insurances
                                    .Select(i => i.PolicyType)
                                    .Distinct()
                                    .ToList();

            //9. Skip first 2 customers and take next 3
            var skippedAndTakenCustomers = customers
                                            .Skip(2)
                                            .Take(3)
                                            .ToList();

            //11. List all customer names and their policy type. If no policy, display "No Policy"
            var customerWithPolicies = from c in customers
                                       join i in insurances on c.CustomerId equals i.CustomerId into custPolicyGroup
                                       from policy in custPolicyGroup.DefaultIfEmpty()
                                       select new
                                       {
                                           CustomerName = c.Name,
                                           PolicyType = policy != null ? policy.PolicyType : "No Policy"
                                       };


        }
    }
}
