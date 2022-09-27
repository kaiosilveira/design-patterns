using Xunit;
using TicTacToe.Domain;

public class BoardStateTest
{
  [Fact]
  public void TestCreation()
  {
    var currentPlayNumber = 1;
    var playedPositions = new string?[9] { "X", null, null, null, null, null, null, null, null };
    var state = new BoardState(currentPlayNumber, playedPositions);

    Assert.Equal(1, state.CurrentPlayNumber);
    Assert.Equal(playedPositions, state.PlayedPositions);
  }
}