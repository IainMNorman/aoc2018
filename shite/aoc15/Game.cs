using System.Linq;

public class Game
{
    public Game(string[] input)
    {
        this.Board = new Board(input);
        this.Board.Render(0);
        this.Run();
    }

    public void Run()
    {
        this.isRunning = true;
        while (this.isRunning)
        {
            var turns = this.Board.Pieces
                .OrderBy(p => p.Point.Y)
                .ThenBy(p => p.Point.X);

            foreach (var pieceTurn in turns)
            {
                pieceTurn.Move();
                pieceTurn.Attack();
            }            
            this.Board.Render(this.Round);
            this.isRunning = !this.Board.isGameOver();
            this.Round++;
        }
    }

    private int Round { get; set; } = 1;

    private Board Board { get; set; }

    private bool isRunning { get; set; }
}