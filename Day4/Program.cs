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
            var containsOneSameSection = 0;

            foreach (var line in lines)
            {
                var pairs = line.Split(",");

                if (GetIsOverlappingSections(pairs[0].Split("-"), pairs[1].Split("-")))
                    overlappingSections++;

                containsOneSameSection += GetContainsOneSameSection(line,
                    pairs[0].Split("-"), pairs[1].Split("-"))
                    ? 1
                    : 0;
            }

            Console.WriteLine($"Overlapping Section: {overlappingSections}");
            Console.WriteLine($"Number of single overlapping sections: {containsOneSameSection}");
        }

        private static bool GetIsOverlappingSections(string[] section1, string[] section2)
        {
            var start1 = int.Parse(section1[0]);
            var end1 = int.Parse(section1[1]);
            var start2 = int.Parse(section2[0]);
            var end2 = int.Parse(section2[1]);

            return (start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1);
        }

        private static bool GetContainsOneSameSection(string line, string[] section1, string[] section2)
        {
            var start1 = int.Parse(section1[0]);
            var end1 = int.Parse(section1[1]);
            var start2 = int.Parse(section2[0]);
            var end2 = int.Parse(section2[1]);

            var range1 = Enumerable.Range(start1, end1 - start1 +1);
            var range2 = Enumerable.Range(start2, end2 - start2 +1);

            // I know there should be a better lambda, or LINQ expression for this. 
            foreach (var i in range1)
            {
                if (range2.Contains(i))
                    return true;
            }

            return false;
        }
    }
}
