using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace aoc12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"d:\temp\aoc12.txt");

            Part1(input);

        }

        private static void Part1(string[] input)
        {
            var initialState = input[0].Substring(15);
            initialState = new String('.', 10) + initialState + new String('.', 2000);
            var currentState = new StringBuilder(initialState);
            var zeroIndex = 10;
            var rules = new List<Rule>();

            for (int i = 2; i < input.Length; i++)
            {
                rules.Add(new Rule() { Pattern = input[i].Substring(0, 5), Result = input[i].Substring(9, 1).ToCharArray()[0] });
            }

            for (long gen = 0; gen < 50000000000; gen++)
            {
                var nextState = new StringBuilder(currentState.ToString());
                foreach (var rule in rules)
                {
                    for (int i = 2; i < initialState.Length - 2; i++)
                    {
                        if (currentState.ToString(i - 2, 5) == rule.Pattern)
                        {
                            nextState[i] = rule.Result;
                        }
                    }
                }
                currentState = nextState;

                var total = 0;
                for (int i = 0; i < currentState.Length; i++)
                {
                    var value = i - zeroIndex;
                    if (currentState.ToString(i, 1) == "#")
                    {
                        total += value;
                    }
                }

                if (gen % 1000 == 0)
                {
                    Console.WriteLine($"{gen + 1} - {total}");
                }
            }

            Console.ReadLine();
        }
    }

    class Rule
    {
        public string Pattern { get; set; }
        public char Result { get; set; }
    }
}
