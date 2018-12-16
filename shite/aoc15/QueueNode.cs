public class QueueNode {
    public QueueNode(Point point, int distance){
        Point = point;
        Distance = distance;
    }

    public Point Point { get; }

    public int Distance { get; set; }
}