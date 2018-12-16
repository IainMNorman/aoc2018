using System;
using System.IO;

namespace aoc15
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("test.txt");

            var testBoard = new Game(File.ReadAllLines("test.txt"));
            //var board = new Game(File.ReadAllLines("input.txt"));
        }
    }
}
