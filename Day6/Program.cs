using System;
using System.Collections.Generic;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buffer = System.IO.File.ReadAllText(@"C:\AdventOfCode\6\input.txt");

            var charList = new List<char>();
            var markerIndexCounter = 0;
            var startIndex = 0;
            for (var index = 0; index < buffer.Length; index++)
            {
                var c = buffer[index];
                if (!charList.Contains(c))
                {
                    charList.Add(c);
                    markerIndexCounter++;
                    if (markerIndexCounter == 4)
                    {
                        startIndex = index;
                        break;
                    }
                }
                else
                {
                    charList.Clear();
                    markerIndexCounter = 0;
                }

            }
            Console.WriteLine($"Index: {startIndex}");
        }
    }
}
