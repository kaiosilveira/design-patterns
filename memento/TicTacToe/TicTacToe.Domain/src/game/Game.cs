namespace TicTacToe.Domain;

public class Game
{
  private Board board;
  private BoardState lastBoardState;

  public Game(Board board)
  {
    this.board = board;
    lastBoardState = board.GetState();
  }

  public void ComputePlay(int playedPosition, string symbol)
  {
    lastBoardState = board.GetState();
    board.AddPlay(playedPosition, symbol);
  }

  public void Undo()
  {
    board.SetState(lastBoardState);
  }
}