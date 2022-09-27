namespace TicTacToe.Domain;

public class InMemoryBoard : Board
{
  public int CurrentPlayNumber { get; private set; }
  public string?[] PlayedPositions { get; private set; }

  public InMemoryBoard()
  {
    PlayedPositions = new string?[9];
  }

  public void AddPlay(int position, string symbol)
  {
    CurrentPlayNumber++;
    PlayedPositions[position] = symbol;
  }

  public BoardState GetState()
  {
    return new BoardState(CurrentPlayNumber, PlayedPositions);
  }

  public void SetState(BoardState state)
  {
    this.CurrentPlayNumber = state.CurrentPlayNumber;
    this.PlayedPositions = state.PlayedPositions;
  }

  public void Draw() {

  }
}
