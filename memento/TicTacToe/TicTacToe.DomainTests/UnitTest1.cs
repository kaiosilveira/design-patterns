using Xunit;
using TicTacToe.Domain;

namespace TicTacToe.DomainTests;

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

public class BoardTest
{
  [Fact]
  public void TestAddsPlay_StoresSymbolAndPositionCorrectly()
  {
    var board = new Board();

    board.AddPlay(position: 5, "X");
    var playedPositions = board.PlayedPositions;

    Assert.Equal("X", playedPositions[5]);
  }

  [Fact]
  public void TestAddsPlay_IncrementsCurrentPlayNumber()
  {
    var board = new Board();
    board.AddPlay(position: 5, "X");
    Assert.Equal(1, board.CurrentPlayNumber);
  }

  [Fact]
  public void TestGetState_ReturnsInitialState()
  {
    var board = new Board();

    var state = board.GetState();

    Assert.Equal(0, state.CurrentPlayNumber);
    Assert.Equal(new string?[9], state.PlayedPositions);
  }

  [Fact]
  public void TestGetState_ReturnsUpdatedStateAfterOnePlay()
  {
    var board = new Board();

    board.AddPlay(position: 5, "X");
    var state = board.GetState();

    Assert.Equal(1, state.CurrentPlayNumber);
    Assert.Equal(
      new string?[9] { null, null, null, null, null, "X", null, null, null },
      state.PlayedPositions
    );
  }

  [Fact]
  public void TestSetState_ChangesTheBoardToPredefinedState()
  {
    var currentPlayNumber = 6;
    var playedPositions = new string?[9]
    {
      null, "X", "O",
      "X", "O", "X",
      "X", "O", null
    };

    var state = new BoardState(currentPlayNumber, playedPositions);

    var board = new Board();
    board.SetState(state);

    Assert.Equal(currentPlayNumber, state.CurrentPlayNumber);
    Assert.Equal(playedPositions, board.PlayedPositions);
  }
}