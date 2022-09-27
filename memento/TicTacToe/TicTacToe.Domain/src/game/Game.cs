namespace TicTacToe.Domain;

public class Game
{
  private Board board;
  private BoardState lastBoardState;
  private string currentPlayer;

  public Game(Board board)
  {
    this.board = board;
    this.currentPlayer = "X";
    lastBoardState = board.GetState();
  }

  public void ComputePlay(int playedPosition)
  {
    lastBoardState = board.GetState();
    currentPlayer = board.GetCurrentPlayNumber() % 2 == 0 ? "X" : "O";
    board.AddPlay(playedPosition, currentPlayer);
  }

  public void Undo()
  {
    board.SetState(lastBoardState);
  }

  public void Draw()
  {
    Console.Clear();
    board.Draw();
  }
}