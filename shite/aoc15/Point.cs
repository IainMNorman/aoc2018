using System;
using System.Collections.Generic;

public class Point
{
    public Point(int x, int y, bool includeAdjacent = true)
    {
        X = x;
        Y = y;

        if (includeAdjacent)
        {
            this.AdjacentPoints = new List<Point>();
            this.AdjacentPoints.Add(new Point(x, y + 1, false));
            this.AdjacentPoints.Add(new Point(x + 1, y, false));
            this.AdjacentPoints.Add(new Point(x - 1, y, false));
            this.AdjacentPoints.Add(new Point(x, y - 1, false));
        }
    }

    public int X { get; set; }
    public int Y { get; set; }

    public List<Point> AdjacentPoints { get; set; }

    public bool IsAdjacent(Point point)
    {
        return (
            (Math.Abs(point.X - this.X) == 1 && point.Y == this.Y) ||
            (Math.Abs(point.Y - this.Y) == 1 && point.X == this.X));
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null) return false;
        Point p = obj as Point;
        if ((System.Object)p == null) return false;
        return (this.X == p.X && (this.Y == p.Y));
    }

    public bool Equals(Point p)
    {
        if ((object)p == null) return false;
        return (this.X == p.X) && (this.Y == p.Y);
    }

    public override int GetHashCode()
    {
        return this.X ^ this.Y;
    }
}