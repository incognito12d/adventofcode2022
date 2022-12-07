using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stackLines= File.ReadLines(@"C:\AdventOfCode\5\input.txt")
                .TakeWhile(line => line.Contains("["))
                .Reverse()
                .ToList();

            var moveLines = File.ReadLines(@"C:\AdventOfCode\5\input.txt")
                .SkipWhile(line => !line.StartsWith("move"))
                .ToList();

            // Part 1 - CrateMover 9000
            var stacks = GetInitialStacks(stackLines);
            stacks = GetCrateMover9000Stacks(moveLines, stacks);
            Console.WriteLine($"CrateMover 9000 results: {GetResultString(stacks)}");

            // Part 2 - CrateMover 9001
            stacks = GetInitialStacks(stackLines);
            GetCrateMover9001Stacks(moveLines, stacks);
            Console.WriteLine($"CrateMover 9001 results: {GetResultString(stacks)}");

        }

        private static Dictionary<int, Stack> GetCrateMover9000Stacks(List<string> moveLines, Dictionary<int, Stack> stacks)
        {
            foreach (var moveLine in moveLines)
            {
                var moveNrOfCrate = int.Parse(moveLine.Split("move ")[1].Split(" from")[0]);
                var fromStackNr = int.Parse(moveLine.Split("from ")[1].Split(" to")[0]);
                var toStackNr = int.Parse(moveLine.Split("to ")[1]);

                for (int i = 0; i < moveNrOfCrate; i++)
                {
                    var crate = stacks[fromStackNr].Pop()?.ToString();
                    stacks[toStackNr].Push(crate);
                }
            }
            return stacks;
        }

        private static Dictionary<int, Stack> GetCrateMover9001Stacks(List<string> moveLines, Dictionary<int, Stack> stacks)
        {
            foreach (var moveLine in moveLines)
            {
                var moveNrOfCrate = int.Parse(moveLine.Split("move ")[1].Split(" from")[0]);
                var fromStackNr = int.Parse(moveLine.Split("from ")[1].Split(" to")[0]);
                var toStackNr = int.Parse(moveLine.Split("to ")[1]);

                var crates = new List<String>();
                for (int i = 0; i < moveNrOfCrate; i++)
                {
                    crates.Add(stacks[fromStackNr].Pop()?.ToString());
                }
                crates.Reverse();
                foreach (var crate in crates)
                {
                    stacks[toStackNr].Push(crate);
                }
            }
            return stacks;
        }

        private static string GetResultString(Dictionary<int, Stack> stacks)
        {
            var resultString = "";
            for (int i = 1; i < stacks.Count() + 1; i++)
            {
                resultString += stacks[i].Pop();
            }
            return resultString;
        }

        private static Dictionary<int, Stack> GetInitialStacks(List<string> stackLines)
        {
            var stacks = new Dictionary<int, Stack>();

            for (int i = 1; i < 10; i++)
            {
                var crates = new Stack();
                stacks.Add(i, crates);
            }

            foreach (var line in stackLines)
            {
                var stackNr = 1;
                for (int i = 0; i < line.Length; i += 4)
                {
                    var box = line.Substring(i, 4);
                    if (box.StartsWith("["))
                    {
                        stacks[stackNr].Push(box[1]);
                    }
                    stackNr++;
                }
            }

            return stacks;
        }
    }
}
