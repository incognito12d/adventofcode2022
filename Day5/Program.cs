using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var useCrateMover9001 = false;

            Console.WriteLine("1: CrateMover 9000 (Part 1)");
            Console.WriteLine("2: CrateMover 9001 (Part 2)");
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    useCrateMover9001 = true;
                    break;
                default:
                    Console.WriteLine("Illegal input");
                    Environment.Exit(-1);
                    break;
            }

            var stackLines = File.ReadLines(@"C:\AdventOfCode\5\input.txt")
                .TakeWhile(line => line.Contains("["))
                .Reverse();

            var stacks = new Dictionary<int, Stack>();
            for (var i = 1; i < 10; i++)
            {
                var crates = new Stack();
                stacks.Add(i, crates);
            }

            foreach (var line in stackLines)
            {
                var stackNr = 1;
                for (var i = 0; i < line.Length; i += 4)
                {
                    var box = line.Substring(i, 4);
                    if (box.StartsWith("["))
                    {
                        stacks[stackNr].Push(box[1]);
                    }
                    stackNr++;
                }
            }

            var moveLines = File.ReadLines(@"C:\AdventOfCode\5\input.txt")
                .SkipWhile(line => !line.StartsWith("move"))
                .ToList();

            foreach (var moveLine in moveLines)
            {
                var moveNrOfCrate = int.Parse(moveLine.Split("move ")[1].Split(" from")[0]);
                var fromStackNr = int.Parse(moveLine.Split("from ")[1].Split(" to")[0]);
                var toStackNr = int.Parse(moveLine.Split("to ")[1]);

                var crates = new List<string>();
                for (var i = 0; i < moveNrOfCrate; i++)
                {
                    crates.Add(stacks[fromStackNr].Pop()?.ToString());  
                    
                }

                if (useCrateMover9001)
                    crates.Reverse();

                foreach (var crate in crates)
                {
                    stacks[toStackNr].Push(crate);
                }
            }

            var result  = "";
            for (var i = 1; i < stacks.Count() + 1; i++)
            {
                result += stacks[i].Pop();
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}
