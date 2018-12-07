using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System.Drawing;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"d:\temp\andy.txt");
            var locations = new List<Point>(50);
            var nRows = 400;
            var nCols = 400;
            var closest = new Point[nRows, nCols];
            var dict = new Dictionary<Point, int>();
            var part2result = 0;

            foreach (var line in lines)
            {
                var x = int.Parse(line.Substring(0, line.IndexOf(',')));
                var y = int.Parse(line.Substring(line.IndexOf(',') + 1));

                locations.Add(new Point(x, y));
            }

            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    var point = new Point(row, col);
                    var ordered = locations.Select(loc => new { coord = loc, distance = ManhattanDistance(loc, point) }).OrderBy(loc => loc.distance);

                    if (ordered.First().distance == (ordered.ElementAt(1)).distance)
                    {
                        closest[row, col] = new Point(-1, -1);
                    }
                    else
                    {
                        closest[row, col] = ordered.First().coord;
                    }
                }
            }

            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    if (dict.ContainsKey(closest[row, col]))
                    {
                        dict[closest[row, col]]++;
                    }
                    else
                    {
                        dict[closest[row, col]] = 1;
                    }
                }
            }

            // Exclude all locations with infinitely many points closest to them
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    if (row == 0 || col == 0 || row == nRows - 1 || col == nCols - 1)
                    {
                        dict[closest[row, col]] = -1;
                    }
                }
            }

            Console.WriteLine(dict.OrderByDescending(d => d.Value).First().Value);

            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    var point = new Point(row, col);
                    var totalDistance = locations.Select(loc => ManhattanDistance(loc, point)).Sum();
                    if (totalDistance < 10000)
                    {
                        part2result++;
                    }
                }
            }

            Console.WriteLine(part2result);

            Console.ReadLine();

        }

        static double ManhattanDistance(Point first, Point second)
        {
            return Math.Abs(first.X - second.X) + Math.Abs(first.Y - second.Y);
        }
    }
}
