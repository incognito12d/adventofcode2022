using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\AdventOfCode\4\input.txt");

            var overlappingSections = 0;

            foreach (var line in lines)
            {
                var pairs = line.Split(",");

                if (GetIsOverlappingSections(pairs[0].Split("-"), pairs[1].Split("-")))
                    overlappingSections++;
            }

            Console.WriteLine($"Overlapping Section: {overlappingSections}");
        }

        private static bool GetIsOverlappingSections(string[] section1, string[] section2)
        {
            var start1 = int.Parse(section1[0]);
            var end1 = int.Parse(section1[1]);
            var start2 = int.Parse(section2[0]);
            var end2 = int.Parse(section2[1]);

            return (start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1);
        }
    }
}
