using Xunit;
using Moq;
using TicTacToe.Domain;

namespace TicTacToe.DomainTests;

public class GameTest
{
  [Fact]
  public void TestComputePlay_AddsPlayToTheBoardForPlayer1()
  {
    var board = new Mock<Board>();
    var playedPosition = 2;

    var game = new Game(board: board.Object);
    game.ComputePlay(playedPosition);

    board
      .Verify(
        b => b.AddPlay(It.Is<int>(i => i == playedPosition), It.Is<string>(s => s == "X")),
        Times.Once()
      );
  }

  [Fact]
  public void TestComputePlay_AddsPlayToTheBoardForPlayer2()
  {
    var board = new Mock<Board>();
    board.Setup(b => b.GetCurrentPlayNumber()).Returns(1);
    var playedPosition = 2;

    var game = new Game(board: board.Object);
    game.ComputePlay(playedPosition);

    board
      .Verify(
        b => b.AddPlay(It.Is<int>(i => i == playedPosition), It.Is<string>(s => s == "O")),
        Times.Once()
      );
  }

  [Fact]
  public void TestUndo_ShouldReturnTheBoardToThePreviousState()
  {
    var currentPlayNumber = 5;
    var playedPositions = new string?[9] {
      null, "O", "X",
      "X", "X", null,
      "O", null, null,
    };

    var state = new BoardState(currentPlayNumber, playedPositions);
    var board = new Mock<Board>();
    board.Setup(b => b.GetState()).Returns(state);

    var game = new Game(board: board.Object);
    game.ComputePlay(playedPosition: 0);

    game.Undo();

    board.Verify(b => b.SetState(state), Times.Once());
  }
}