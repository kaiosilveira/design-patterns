
namespace TicTacToe.Domain;

public class BoardState
{
  public int CurrentPlayNumber { get; private set; }
  public string?[] PlayedPositions { get; private set; }

  public BoardState(int currentPlayNumber, string?[] playedPositions)
  {
    this.CurrentPlayNumber = currentPlayNumber;
    this.PlayedPositions = playedPositions;
  }
}