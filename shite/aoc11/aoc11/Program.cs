using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc11
{
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main(string[] args)
        {
            Day11(42);
            Console.ReadLine();
        }

        static void Day11(int sn)
        {
            var grid = new int[301, 301];

            for (var x = 1; x <= 300; x++)
            {
                for (var y = 1; y <= 300; y++)
                {
                    grid[x, y] = GetCellValue(x, y, sn);
                }
            }

            var part1 = FindLargestSquare(3, grid, sn);
            Console.WriteLine($"{part1.Item2},{part1.Item3}");

            var part2 = new Tuple<int, int, int, int>(0, 0, 0, 0);

            for (var size = 1; size < 301; size++)
            {
                var candidate = FindLargestSquare(size, grid, sn);
                if (candidate.Item4 > part2.Item4)
                {
                    part2 = candidate;
                }
                Console.WriteLine($"Cur Size {candidate.Item1}: {candidate.Item2},{candidate.Item3} power {candidate.Item4}");
                
            }
            Console.WriteLine($"Max Size {part2.Item1}: {part2.Item2},{part2.Item3} power {part2.Item4}");

            Console.ReadLine();
        }

        static Tuple<int, int, int, int> FindLargestSquare(int size, int[,] grid, int sn)
        {
            var maxTotal = int.MinValue;
            var maxX = 0;
            var maxY = 0;

            for (var x = 1; x < (301 - size); x++)
            {
                for (var y = 1; y < (301 - size); y++)
                {
                    var total = 0;
                    for (var sx = x; sx < x + size; sx++)
                    {
                        for (var sy = y; sy < y + size; sy++)
                        {
                            total += GetCellValue(sx, sy, sn);
                        }
                    }

                    if (total > maxTotal)
                    {
                        maxTotal = total;
                        maxX = x;
                        maxY = y;
                    }
                }
            }

            return new Tuple<int, int, int, int>(size, maxX, maxY, maxTotal);
        }

        static int GetCellValue(int x, int y, int sn)
        {
            var rackId = x + 10;
            var power = y * rackId;
            power += sn;
            power *= rackId;

            if (power < 100)
            {
                return -5;
            }

            return ((int)Math.Abs(power / 100 % 10)) - 5;
        }
    }
}
