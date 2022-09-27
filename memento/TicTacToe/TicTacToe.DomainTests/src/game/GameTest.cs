using Xunit;
using Moq;
using TicTacToe.Domain;

namespace TicTacToe.DomainTests;

public class GameTest
{
  [Fact]
  public void TestComputePlay_AddsPlayToTheBoard()
  {
    var board = new Mock<Board>();
    var playedPosition = 2;
    var symbol = "X";

    var game = new Game(board: board.Object);
    game.ComputePlay(playedPosition, symbol);

    board
      .Verify(
        b => b.AddPlay(It.Is<int>(i => i == playedPosition), It.Is<string>(s => s == symbol)),
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
    game.ComputePlay(playedPosition: 0, symbol: "O");

    game.Undo();

    board.Verify(b => b.SetState(state), Times.Once());
  }
}