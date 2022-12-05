using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    internal class Program
    {
        private static char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\AdventOfCode\3\input.txt");

            // Part 1
            var totalPriorityValue = (from line in lines 
                let firstCompartment = line.Substring(0, line.Length / 2) 
                let secondCompartment = line.Substring(line.Length / 2, line.Length / 2) 
                select GetMisplacedItemPriority(firstCompartment, secondCompartment)).Sum();

            Console.WriteLine($"Misplaced Items Priority Value: {totalPriorityValue}");

            // Part 2
            var totalBadgeValue = 0;
            var group = new List<string>();

            foreach (var line in lines)
            {
                group.Add(line);
                if (group.Count == 3)
                {
                    totalBadgeValue += GetGroupBadgeValue(group);
                    group.Clear();
                }
            }
            Console.WriteLine($"Badge Values: {totalBadgeValue}");
        }

        private static int GetMisplacedItemPriority(string firstCompartment, string secondCompartment)
        {
            var duplicate = firstCompartment.First(c => secondCompartment.Contains((char) c));

            return GetCharValue(duplicate);
        }

        private static int GetGroupBadgeValue(List<string> group)
        {
            var badgeCharacter = group[0].First(c => group[1].Contains(c) && group[2].Contains(c));

            return GetCharValue(badgeCharacter);
        }

        private static int GetCharValue(char c)
        {
            return Char.IsUpper(c)
                ? Array.IndexOf(_alphabet, c) + 27
                : Array.IndexOf(_alphabet, Char.ToUpper(c)) + 1;
        }
    }
}
