using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc7
{
    using System.IO;
    using System.Text.RegularExpressions;

    static class Program
    {
        static List<Step> Steps { get; set; }
        static List<char> Output { get; set; }
        static Queue<Step> Queue { get; set; }

        static void Main()
        {
            var testInput = File.ReadAllLines(@"d:\temp\aoc7test.txt");
            Part1(testInput);

            var input = File.ReadAllLines(@"d:\temp\aoc7.txt");
            Part1(input);

            Console.ReadLine();
        }

        static void Part1(IEnumerable<string> input)
        {
            Output = new List<char>();
            Steps = new List<Step>();
            Queue = new Queue<Step>();

            foreach (var line in input)
            {
                var matches = Regex.Matches(line, "[A-Z]");
                var step = (char)matches[2].Value[0];
                var pre = (char)matches[1].Value[0];

                if (Steps.Any(i => i.Name == step))
                {
                    Steps.First(i => i.Name == step).Prerequisites.Add(pre);
                }
                else
                {
                    var ins = new Step { Name = step };
                    ins.Prerequisites.Add(pre);
                    Steps.Add(ins);
                }
            }

            FindFirstInstructions();
            ProcessQueue();
            Console.WriteLine(string.Join("", Output));
        }

        static void FindFirstInstructions()
        {
            var allSteps = Steps.Select(x => x.Name);
            var allPres = Steps.SelectMany(x => x.Prerequisites);
            var firsts = allPres.Except(allSteps).OrderBy(x => x);

            foreach (var stepName in firsts)
            {
                var firstStep = new Step() { Name = stepName };
                Steps.Add(firstStep);
                Queue.Enqueue(firstStep);
            }
        }

        static void ProcessQueue()
        {
            while (Queue.Count > 0)
            {
                var step = Queue.Dequeue();


                // check all pres are complete
                if (step.PrerequisitesSatisfied(Output))
                {
                    // all pres satisfied we can add to output if it's not already there.
                    step.Done = true;
                    if (!Output.Contains(step.Name))
                    {
                        Output.Add(step.Name);
                    }

                    // process steps that can now be done
                    Queue.Clear();

                    var nextSteps = Steps
                        .Where(x => x.PrerequisitesSatisfied(Output) && !x.Done)
                        .OrderBy(o => o.Name);

                    foreach (var nextStep in nextSteps)
                    {
                        Queue.Enqueue(nextStep);
                    }
                }
                else
                {
                    // process all pres in alpha order
                    foreach (var stepName in step.Prerequisites)
                    {
                        Queue.Enqueue(Steps.First(x => x.Name == stepName));
                    }
                }
            }
        }
    }

    public class Step
    {
        public char Name { get; set; }
        public List<char> Prerequisites { get; set; } = new List<char>();

        public bool Done { get; set; }

        public bool PrerequisitesSatisfied(List<char> done)
        {
            return Prerequisites.All(done.Contains);
        }
    }
}
