using System;
using System.Collections.Generic;
using System.Linq;

public class Piece
{
    public Piece(Point point, PieceType type, Board board)
    {
        Point = point;
        Type = type;
        Board = board;
        this.HitPoints = 200;
        this.AttackPower = 3;
    }

    public Point Point { get; }
    public PieceType Type { get; }
    public int HitPoints { get; set; }
    public int AttackPower { get; set; }
    private Board Board { get; }

    private List<Piece> Enemies
    {
        get
        {
            return this.Board.Pieces.Where(p => p.Type != this.Type)
                .OrderBy(p => p.Point.Y).ThenBy(p => p.Point.X).ToList(); ;
        }
    }

    private List<Piece> Attackable
    {
        get
        {
            return this.Enemies.Where(p => p.Point.IsAdjacent(this.Point)).ToList();
        }
    }

    private List<Point> GetTargetSpaces()
    {
        var targetSpaces = new List<Point>();
        this.Enemies.ForEach(e =>
        {
            e.Point.AdjacentPoints.ForEach(p =>
            {
                if (this.Board.Tiles[p].Type == TileType.Floor &&
                    !this.Board.Pieces.Any(x => x.Point == p))
                {
                    if (!targetSpaces.Contains(p))
                    {
                        targetSpaces.Add(p);
                    }
                }
            });
        });
        return targetSpaces;
    }

    private void GetShortestRoutes(Point target)
    {
        var startPoint = this.Point;
        var visited = new Dictionary<Point, int>();
        visited.Add(startPoint, 0);
        var queue = new Queue<QueueNode>();

        var startNode = new QueueNode(this.Point, 0);

        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (target == currentNode.Point) {
                visited.Add(currentNode.Point, currentNode.Distance + 1);
                break;
            }

            // queue valid neighbours
            currentNode.Point.AdjacentPoints.ForEach(p =>
            {
                if (this.Board.Tiles[p].Type == TileType.Floor &&
                    !this.Board.Pieces.Any(x => x.Point == p) &&
                    !visited.ContainsKey(p))
                {
                    visited.Add(p,currentNode.Distance + 1);
                    queue.Enqueue(new QueueNode(p, currentNode.Distance + 1));
                }
            });
        }

        // is there a path?
        if (visited.ContainsKey(target)){
            // back trace visited to find actual path favouring reading order
        }
        else {
            // no path
        }
    }

    public void Turn()
    {
        this.Move();
        this.Attack();
    }

    public void Move()
    {
        if (this.Attackable.Any()) return;

        // find points adjacent to all enemies that are floor and not occupied

        var tp = this.GetTargetSpaces();

        // eliminate ones there is no path to

        // find the colleciton of nearest by manhatten distance

        // find first of those in reading order this is our target to move to

        // find collection of shortest paths to target square

        // pick first point of those paths that's first in reading order

        // move to that point
    }

    public void Attack()
    {
        if (this.Attackable.Any()) this.Hit(this.Attackable.First());
    }

    public void Hit(Piece target)
    {
        target.HitPoints -= this.AttackPower;
    }
}