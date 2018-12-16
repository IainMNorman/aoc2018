public class Tile {
    public Tile(Point point, TileType type) {
        Point = point;
        Type = type;
    }

    public Point Point { get; }
    public TileType Type { get; }
}