using System;
using System.Collections.Generic;
using System.Linq;

public class Board
{
    public Board(string[] input)
    {
        this.Height = input.Length;
        this.Width = input.Max(i => i.Length);
        GenerateTiles(input);
        CreatePieces(input);
    }

    public Dictionary<Point, Tile> Tiles { get; set; } 
        = new Dictionary<Point, Tile>();
    public List<Piece> Pieces = new List<Piece>();

    public Board(int width, int height)
    {
        this.Width = width;
        this.Height = height;

    }
    public int Width { get; set; }

    public int Height { get; set; }

    internal bool isGameOver()
    {
        return false;
    }

    private void GenerateTiles(string[] input)
    {
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                TileType tileType = TileType.Floor;
                if (input[y][x] == '#')
                {
                    tileType = TileType.Wall;
                }
                Tiles.Add(new Point(x,y), new Tile(new Point(x, y), tileType));
            }
        }
    }

    private void CreatePieces(string[] input)
    {
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                if (input[y][x] == 'E')
                {
                    Pieces.Add(new Piece(new Point(x, y), PieceType.Elf, this));
                }
                if (input[y][x] == 'G')
                {
                    Pieces.Add(new Piece(new Point(x, y), PieceType.Gobiln, this));
                }
            }
        }
    }

    public void Render(int round)
    {
        Console.Clear();
        Console.WriteLine($"Round {round}");
        var point = new Point(0, 0);
        for (int y = 0; y < this.Height; y++)
        {
            for (int x = 0; x < this.Width; x++)
            {
                point.X = x;
                point.Y = y;
                var piece = Pieces.FirstOrDefault(p => p.Point.X == x && p.Point.Y == y);

                if (piece != null)
                {
                    Console.Write(piece.Type.ToString().Substring(0, 1));
                }
                else
                {
                    if (Tiles[point].Type == TileType.Wall)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
            }
            Console.Write("\n");
        }
    }
}