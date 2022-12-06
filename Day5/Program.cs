using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stackLines= File.ReadLines(@"C:\AdventOfCode\5\input.txt")
                .TakeWhile(line => line.Contains("["))
                .Reverse();

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

            var moveLines = File.ReadLines(@"C:\AdventOfCode\5\input.txt")
                .SkipWhile(line => !line.StartsWith("move"))
                .ToList();

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

            var result  = "";
            for (int i = 1; i < stacks.Count() + 1; i++)
            {
                result += stacks[i].Pop();
            }

            Console.WriteLine(result);
        }
    }
}
