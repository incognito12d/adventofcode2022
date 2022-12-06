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
                .TakeWhile(line => line.Contains("["));

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
                .SkipWhile(line => !line.StartsWith("move"));

            Console.WriteLine("Hello World!");
        }
    }
}
