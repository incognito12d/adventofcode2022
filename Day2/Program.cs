using System;
using System.Collections.Specialized;
using System.Linq;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\AdventOfCode\2\input.txt");
            
            var totalScoreV1 = lines.Sum(line => GetRoundOutcomeV1(line[0], line[2]));
            Console.WriteLine($"Total ScoreV1: {totalScoreV1}");

            var totalScoreV2 = lines.Sum(line => GetRoundOutcomeV2(line[0], line[2]));
            Console.WriteLine($"Total ScoreV2: {totalScoreV2}");
        }

        private static int GetRoundOutcomeV1(char opponentMove, char counterMove)
        {
            var roundScore = 0;

            roundScore += GetMoveScore(counterMove);
            roundScore += GetOutcomeScore(opponentMove, counterMove);

            return roundScore;
        }

        private static int GetRoundOutcomeV2(char opponentMove, char counterMove)
        {
            var roundScore = 0;

            roundScore += GetMoveScore(GetV2CounterMove(opponentMove, counterMove));
            roundScore += GetOutcomeScore(opponentMove, GetV2CounterMove(opponentMove, counterMove));

            return roundScore;
        }

        private static char GetV2CounterMove(char opponentMove, char predictedResult)
        {
            return predictedResult switch
            {
                // Loose
                'X' => opponentMove switch
                {
                    'A' => 'Z',
                    'B' => 'X',
                    'C' => 'Y',
                    _ => throw new Exception("Unsupported move")
                },
                // Draw
                'Y' => opponentMove switch
                {
                    'A' => 'X',
                    'B' => 'Y',
                    'C' => 'Z',
                    _ => throw new Exception("Unsupported move")
                },
                // Win
                'Z' => opponentMove switch
                {
                    'C' => 'X',
                    'B' => 'Z',
                    'A' => 'Y',
                    _ => throw new Exception("Unsupported move")
                },
                _ => throw new Exception("Unsupported move")
            };
        }


        private static int GetMoveScore(char counterMove)
        {
            return counterMove switch
            {
                'X' => 1,
                'Y' => 2,
                'Z' => 3,
                _ => throw new Exception("Unsupported move")
            };
        }

        private static int GetOutcomeScore(char opponentMove, char counterMove)
        {
            switch (opponentMove)
            {
                case 'A' when counterMove == 'X':
                case 'B' when counterMove == 'Y':
                case 'C' when counterMove == 'Z':
                    return 3;
                case 'A' when counterMove == 'Y':
                case 'B' when counterMove == 'Z':
                case 'C' when counterMove == 'X':
                    return 6;
                default:
                    return 0;
            }
        }
        
    }
}
