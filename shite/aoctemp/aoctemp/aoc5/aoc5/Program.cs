using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc5
{
    public static class Program
    {
        static string _part1String;

        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"d:\temp\aoc5.txt");
            Console.WriteLine(Part1(input));
            Console.WriteLine(Part2(_part1String));
            //Console.ReadLine();
        }

        static int Part1(string input)
        {
            var polymer = input.ToCharArray().ToList();
            var prevLength = polymer.Count;

            while (true)
            {
                polymer = RemoveOnePair(polymer);
                if (polymer.Count == prevLength)
                {
                    _part1String = string.Join("", polymer);
                    return polymer.Count;
                }
                else
                {
                    prevLength = polymer.Count;
                }
            }
        }

        static int Part2(string input)
        {
            var shortest = input.Length;

            for (var i = 65; i < 91; i++)
            {
                var candidate = input.Replace(((char)i).ToString(), string.Empty)
                    .Replace(((char)(i + 32)).ToString(), string.Empty);
                var length = Part1(candidate);

                if (length < shortest)
                {
                    shortest = length;
                }
            }

            return shortest;
        }

        static List<char> RemoveOnePair(List<char> polymer)
        {
            for (var i = 1; i < polymer.Count; i++)
            {
                if (polymer[i] == polymer[i - 1] + 32 || polymer[i] == polymer[i - 1] - 32)
                {
                    polymer.RemoveRange(i - 1, 2);
                    return polymer;
                }
            }
            return polymer;
        }
    }
}
