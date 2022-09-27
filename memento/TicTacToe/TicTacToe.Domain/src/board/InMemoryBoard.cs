namespace TicTacToe.Domain;

public class InMemoryBoard : Board
{
  public int CurrentPlayNumber { get; private set; }
  public string?[] PlayedPositions { get; private set; }

  public InMemoryBoard()
  {
    PlayedPositions = new string?[9] { null, null, null, null, null, null, null, null, null };
  }

  public void AddPlay(int position, string symbol)
  {
    CurrentPlayNumber++;
    PlayedPositions[position] = symbol;
  }

  public BoardState GetState()
  {
    var clone = new string?[9];
    return new BoardState(CurrentPlayNumber, playedPositions: (string?[])PlayedPositions.Clone());
  }

  public void SetState(BoardState state)
  {
    this.CurrentPlayNumber = state.CurrentPlayNumber;
    this.PlayedPositions = state.PlayedPositions;
  }

  public void Draw()
  {
    var firstRow = new string?[3] { PlayedPositions[0], PlayedPositions[1], PlayedPositions[2] };
    var secondRow = new string?[3] { PlayedPositions[3], PlayedPositions[4], PlayedPositions[5] };
    var thirdRow = new string?[3] { PlayedPositions[6], PlayedPositions[7], PlayedPositions[8] };

    Console.WriteLine(String.Join(" | ", firstRow.ToList().Select(item => item == null ? " " : item)));
    Console.WriteLine(String.Join(" | ", secondRow.ToList().Select(item => item == null ? " " : item)));
    Console.WriteLine(String.Join(" | ", thirdRow.ToList().Select(item => item == null ? " " : item)));
  }

  public int GetCurrentPlayNumber() {
    return CurrentPlayNumber;
  }
}
