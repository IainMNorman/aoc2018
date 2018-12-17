using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    using System.Collections;
    using System.Diagnostics.Eventing.Reader;
    using System.Xml.Schema;

    class Program
    {
        static void Main(string[] args)
        {
            Part1(5, 10);
            Part1(9, 10);
            Part1(18, 10);
            Part1(2018, 10);
            Part1(360781, 10);
            Part1(409551, 10);

            Part2(51589,5);
            Part2(01245,5);
            Part2(92510,5);
            Part2(59414,5);
            Part2(409551,6);
            Part2(084601, 6);
            Console.ReadLine();
        }

        static void Part1(int input, int required)
        {
            var rp = new LinkedList<int>();

            rp.AddFirst(3);
            rp.AddLast(7);

            var elves = new List<Elf>();

            elves.Add(new Elf(rp.First));
            elves.Add(new Elf(rp.Last));

            var running = true;

            while (running)
            {
                // create new recipes
                var total = elves.Sum(x => x.Node.Value);

                if (total >= 10)
                {
                    // split and add two new recipes
                    rp.AddLast(1);
                    rp.AddLast(total - 10);
                }
                else
                {
                    // add one new recipe
                    rp.AddLast(total);
                }

                // move elfs
                foreach (var elf in elves)
                {
                    var currentValue = elf.Node.Value;

                    for (int i = 0; i < currentValue + 1; i++)
                    {
                        elf.Node = elf.Node.Next ?? rp.First;
                    }
                }

                if (rp.Count >= input + required)
                {
                    running = false;
                }
            }

            Console.WriteLine(string.Join("", rp.Select(x => x.ToString()).ToArray(), input, required));

        }

        static void Part2(int input, int noofDigits)
        {
            var rp = new LinkedList<int>();

            rp.AddFirst(3);
            rp.AddLast(7);

            var elves = new List<Elf>();

            elves.Add(new Elf(rp.First));
            elves.Add(new Elf(rp.Last));

            var running = true;

            while (running)
            {
                // create new recipes
                var total = elves.Sum(x => x.Node.Value);

                if (total >= 10)
                {
                    // split and add two new recipes
                    rp.AddLast(1);

                    if (CheckDone(input, rp, noofDigits))
                    {
                        break;
                    }

                    rp.AddLast(total - 10);

                    if (CheckDone(input, rp, noofDigits))
                    {
                        break;
                    };
                }
                else
                {
                    // add one new recipe
                    rp.AddLast(total);

                    if (CheckDone(input, rp, noofDigits))
                    {
                        break;
                    }
                }

                // move elfs
                foreach (var elf in elves)
                {
                    var currentValue = elf.Node.Value;

                    for (int i = 0; i < currentValue + 1; i++)
                    {
                        elf.Node = elf.Node.Next ?? rp.First;
                    }
                }

                
            }

            Console.WriteLine(rp.Count - noofDigits);
        }

        static bool CheckDone(int input, LinkedList<int> rp, double noofDigits)
        {
            if (rp.Count > noofDigits)
            {
                var multiplier = 1;
                var node = rp.Last;
                var last5 = 0;
                for (int i = 0; i < noofDigits; i++)
                {
                    last5 += node.Value * multiplier;
                    multiplier *= 10;
                    node = node.Previous;
                }

                if (last5 == input)
                {
                    return true;
                }

                //if (rp.Count % 1000000 <= 1) Console.WriteLine(rp.Count);
            }

            return false;
        }
    }

    public class Elf
    {
        public Elf(LinkedListNode<int> node)
        {
            this.Node = node;
        }

        public LinkedListNode<int> Node { get; set; }
    }
}



