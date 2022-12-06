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

                var section1 = pairs[0].Split("-");
                var section2 = pairs[1].Split("-");

                if (GetIsOverlappingSections(line, section1, section2))
                    overlappingSections++;
            }

            Console.WriteLine($"Overlapping Section: {overlappingSections}");
        }

        private static bool GetIsOverlappingSections(string line, string[] section1, string[] section2)
        {
            var start1 = int.Parse(section1[0]);
            var end1 = int.Parse(section1[1]);
            var start2 = int.Parse(section2[0]);
            var end2 = int.Parse(section2[1]);

            var result1 = start1 >= start2 && end1 <= end2
            var result2 = start2 >= start1 && end2 <= end1;

            return result1 || result2;
        }
    }
}
