using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var lines = System.IO.File.ReadAllLines(@"C:\AdventOfCode\1\input.txt");

            var expedition = new List<Elf>();

            var currentEmployeeNumber = 1;
            var provisionList = new List<FoodItem>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    var elf = new Elf
                    {
                        employeeNumber = currentEmployeeNumber,
                        Provisions = provisionList
                    };
                    expedition.Add(elf);

                    currentEmployeeNumber++;
                    provisionList = new List<FoodItem>();

                    continue;

                } else
                {
                    provisionList.Add(new FoodItem { calories = int.Parse(line) });
                }

            }

            Console.WriteLine($"Expedition consists of {expedition.Count} elves");

            var sortedList = expedition.OrderByDescending(i => i.GetProvisionCalorieCount());

            // Part 1
            var heaviestCalorieLoad = sortedList.First();

            Console.WriteLine($"Answer: Elf nr {heaviestCalorieLoad.employeeNumber}," +
                $" with a provision of {heaviestCalorieLoad.GetProvisionCalorieCount()}");

            // Part 2
            var top3hoggers = sortedList.Take(3).ToList();
            var top3provisionsList = top3hoggers.Sum(x => x.GetProvisionCalorieCount());

            Console.WriteLine($"Answer: Elf nr {top3hoggers[0].employeeNumber}, " +
                $"nr {top3hoggers[1].employeeNumber} " +
                $"and {top3hoggers[2].employeeNumber}," +
                $" with a calorie count of {top3provisionsList} calories");

        }
    }
}
