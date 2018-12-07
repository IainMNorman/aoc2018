using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc6
{
    using System.IO;

    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\ntest no rings");
            Part1(File.ReadAllLines(@"d:\temp\aoc6test.txt"),32,0);
            Console.WriteLine("\ntest 1 ring");
            Part1(File.ReadAllLines(@"d:\temp\aoc6test.txt"), 32, 1);
            Console.WriteLine("\ntest 2 rings");
            Part1(File.ReadAllLines(@"d:\temp\aoc6test.txt"), 32, 2);
            Console.WriteLine("\niain no rings");
            Part1(File.ReadAllLines(@"d:\temp\aoc6.txt"),10000,0);
            Console.WriteLine("\niain 1 ring");
            Part1(File.ReadAllLines(@"d:\temp\aoc6.txt"), 10000, 1);
            Console.WriteLine("\niain 2 rings");
            Part1(File.ReadAllLines(@"d:\temp\aoc6.txt"), 10000, 2);
            Console.WriteLine("\nbrian no rings");
            Part1(File.ReadAllLines(@"d:\temp\brian.txt"), 10000, 0);
            Console.WriteLine("\nbrian 1 ring");
            Part1(File.ReadAllLines(@"d:\temp\brian.txt"), 10000, 1);
            Console.WriteLine("\nbrian 2 rings");
            Part1(File.ReadAllLines(@"d:\temp\brian.txt"), 10000, 2);
            Console.WriteLine("\nandy no rings");
            Part1(File.ReadAllLines(@"d:\temp\andy.txt"), 10000, 0);
            Console.WriteLine("\nandy 1 ring");
            Part1(File.ReadAllLines(@"d:\temp\andy.txt"), 10000, 1);
            Console.WriteLine("\nandy 2 rings");
            Part1(File.ReadAllLines(@"d:\temp\andy.txt"), 10000, 2);

            Console.ReadLine();
        }

        static int Part1(string[] input, int maxDist, int extraRings)
        {
            var coords = new List<Coordinate>();
            foreach (var line in input)
            {
                var pair = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                coords.Add(new Coordinate() { X = int.Parse(pair[0]), Y = int.Parse(pair[1]) });
            }

            var top = coords.Min(c => c.Y);
            var bottom = coords.Max(c => c.Y);
            var left = coords.Min(c => c.X);
            var right = coords.Max(c => c.X);

            for (int x = left - extraRings; x < right + extraRings; x++)
            {
                for (int y = top - extraRings; y < bottom + extraRings; y++)
                {
                    // find nearest Coordinate for this location
                    var min = coords.Min(c => c.DistanceToLocation(x, y));
                    var closest = coords.Where(c => c.DistanceToLocation(x, y) == min).ToList();
                    if (closest.Count() == 1)
                    {
                        closest.First().Locations.Add(new Location() { X = x, Y = y });
                    }
                }
            }

            foreach (var c in coords)
            {
                foreach (var l in c.Locations)
                {
                    if (l.X < left || l.X > right || l.Y < top || l.Y > bottom)
                    {
                        c.Infinite = true;
                        break;
                    }
                }
            }

            Console.WriteLine((coords.Where(c => !c.Infinite).Max(c => c.Locations.Count())));

            var totalArea = 0;

            extraRings = 0;

            for (int x = left - extraRings; x < right + extraRings; x++)
            {
                for (int y = top - extraRings; y < bottom + extraRings; y++)
                {
                    var sum = coords.Sum(c => c.DistanceToLocation(x, y));
                    if (sum < maxDist)
                    {
                        totalArea++;
                    }
                }
            }

            Console.WriteLine(totalArea);
            return 0;
        }

        class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }

            public bool Infinite = false;

            public List<Location> Locations { get; set; } = new List<Location>();

            public int DistanceToLocation(int x, int y)
            {
                return Math.Abs(this.X - x) + Math.Abs(this.Y - y);
            }
        }

        class Location
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
