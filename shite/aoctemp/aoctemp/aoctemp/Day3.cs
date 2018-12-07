using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoctemp
{
    using System.IO;
    using System.Text.RegularExpressions;
    using Console = System.Console;

    public static class Day3
    {
        public static void Part1()
        {
            var rects = File.ReadAllLines("d:/temp/day3.txt");
            var coords = new Dictionary<Tuple<int, int>, int>();

            foreach (var rect in rects)
            {
                var x = int.Parse(Regex.Match(rect, @"\s(\d+?),").Groups[1].Value);
                var y = int.Parse(Regex.Match(rect, @",(\d+?):").Groups[1].Value);
                var w = int.Parse(Regex.Match(rect, @"\s(\d+?)x").Groups[1].Value);
                var h = int.Parse(Regex.Match(rect, @"x(\d+?)$").Groups[1].Value);

                for (var i = x; i < (x + w); i++)
                {
                    for (var j = y; j < (y + h); j++)
                    {
                        var coord = new Tuple<int, int>(i, j);
                        if (coords.ContainsKey(coord))
                        {
                            coords[coord]++;
                        }
                        else
                        {
                            coords.Add(coord, 1);
                        }
                    }
                }
            }

            var count = coords.Count(c => c.Value > 1);
            Console.WriteLine($"Total in dict: {coords.Count()}");
            Console.WriteLine($"Total overlap: {count}");

            foreach (var rect in rects)
            {
                var noverlap = true;

                var id = int.Parse(Regex.Match(rect, @"#(\d+?)\s").Groups[1].Value);
                var x = int.Parse(Regex.Match(rect, @"\s(\d+?),").Groups[1].Value);
                var y = int.Parse(Regex.Match(rect, @",(\d+?):").Groups[1].Value);
                var w = int.Parse(Regex.Match(rect, @"\s(\d+?)x").Groups[1].Value);
                var h = int.Parse(Regex.Match(rect, @"x(\d+?)$").Groups[1].Value);

                for (var i = x; i < (x + w) && noverlap; i++)
                {
                    for (var j = y; j < (y + h) && noverlap; j++)
                    {
                        var coord = new Tuple<int, int>(i, j);
                        if (coords[coord] > 1)
                        {
                            noverlap = false;
                        }
                    }
                }

                if (noverlap)
                {
                    Console.WriteLine($"Id of noverlap: {id}");
                }
            }
        }
    }
}
