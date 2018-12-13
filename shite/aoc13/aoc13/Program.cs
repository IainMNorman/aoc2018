using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc13
{
    using System.ComponentModel.Design;
    using System.Data;
    using System.IO;
    using System.Numerics;
    using System.Runtime.CompilerServices;


    internal static class Program
    {
        static readonly Dictionary<Vector2, char> Map = new Dictionary<Vector2, char>();
        static List<Cart> carts = new List<Cart>();

        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"d:\temp\aoc13.txt");
            Part1(input);
        }

        static void Part1(string[] input)
        {
            var running = true;

            var width = input.Max(x => x.Length);
            var height = input.Length;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    switch (input[y][x])
                    {
                        case '|':
                            Map.Add(new Vector2(x, y), '|');
                            break;
                        case '-':
                            Map.Add(new Vector2(x, y), '-');
                            break;
                        case '/':
                            Map.Add(new Vector2(x, y), '/');
                            break;
                        case '\\':
                            Map.Add(new Vector2(x, y), '\\');
                            break;
                        case '+':
                            Map.Add(new Vector2(x, y), '+');
                            break;
                        case '^':
                            carts.Add(new Cart(new Vector2(x, y), Directions.Up));
                            break;
                        case '>':
                            carts.Add(new Cart(new Vector2(x, y), Directions.Right));
                            break;
                        case 'v':
                            carts.Add(new Cart(new Vector2(x, y), Directions.Down));
                            break;
                        case '<':
                            carts.Add(new Cart(new Vector2(x, y), Directions.Left));
                            break;
                        default:
                            break;

                    }
                }
            }
            //Render(width, height);
            while (running)
            {
                

                foreach (var cart in carts)
                {
                    cart.Move(Map);
                }
                //Render(width, height);
                if (CheckCollisions()) running = false;
            }

            Console.ReadLine();
        }

        static bool CheckCollisions()
        {
            var collisions = carts.GroupBy(x => x.Position).Select(g => new
            {
                g.Key,
                Count = g.Count()
            }).Where(x => x.Count > 1);

            if (!collisions.Any()) return false;

            foreach (var collision in collisions)
            {
                var pos = collision.Key;

                Console.WriteLine($"Collision at {pos.X},{pos.Y}");

                carts.RemoveAll(x => x.Position == pos);
            }

            

            if (carts.Count > 1) return false;

            Console.WriteLine($"Last cart at {carts.First().Position.X},{carts.First().Position.Y}");

            return true;
        }

        static void Render(int width, int height)
        {
            Console.Clear();
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pos = new Vector2(x, y);
                    if (carts.Any(c => c.Position == pos))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(Map.ContainsKey(pos) ? Map[pos] : ' ');
                    }
                }

                Console.Write('\n');
            }
        }
    }

    public static class Directions
    {
        public static Vector2 Right = new Vector2(1, 0);
        public static Vector2 Down = new Vector2(0, 1);
        public static Vector2 Left = new Vector2(-1, 0);
        public static Vector2 Up = new Vector2(0, -1);
    }

    public enum Intersection
    {
        Left,
        Straight,
        Right
    }

    public class Cart
    {
        public Cart(Vector2 position, Vector2 direction)
        {
            this.Direction = direction;
            this.Position = position;
        }

        public Vector2 Direction { get; set; }

        public Vector2 Position { get; set; }

        Intersection NextIntersection { get; set; } = Intersection.Left;


        public void Move(Dictionary<Vector2, char> map)
        {
            this.Position += this.Direction;
            this.TurnIfNeedBe(map);
        }

        void TurnIfNeedBe(IReadOnlyDictionary<Vector2, char> map)
        {
            if (!map.ContainsKey(this.Position)) return;
            var turn = map[this.Position];

            switch (turn)
            {
                case '+':
                    this.TurnAtIntersection();
                    break;
                case '\\':
                    this.TurnAtBackSlash();
                    break;
                case '/':
                    this.TurnAtFwdSlash();
                    break;
                default:
                    break;
            }
        }

        void TurnAtBackSlash()
        {
            if (this.Direction == Directions.Right) { this.TurnRight(); return; }
            if (this.Direction == Directions.Down) { this.TurnLeft(); return; }
            if (this.Direction == Directions.Left) { this.TurnRight(); return; }
            if (this.Direction == Directions.Up) this.TurnLeft();
        }

        void TurnAtFwdSlash()
        {
            if (this.Direction == Directions.Right) { this.TurnLeft(); return; }
            if (this.Direction == Directions.Down) { this.TurnRight(); return; }
            if (this.Direction == Directions.Left) { this.TurnLeft(); return; }
            if (this.Direction == Directions.Up) this.TurnRight();
        }

        void TurnLeft()
        {
            this.Direction = new Vector2(this.Direction.Y, -this.Direction.X);
        }

        void TurnRight()
        {
            this.Direction = new Vector2(-this.Direction.Y, this.Direction.X);
        }


        void TurnAtIntersection()
        {
            switch (this.NextIntersection)
            {
                case Intersection.Left:
                    this.TurnLeft();
                    this.NextIntersection = Intersection.Straight;
                    break;
                case Intersection.Straight:
                    this.NextIntersection = Intersection.Right;
                    break;
                case Intersection.Right:
                    this.TurnRight();
                    this.NextIntersection = Intersection.Left;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
