using Xunit;
using MazeGame.MazeItems.Bombed;
using MazeGame.Enumerators;

namespace MazeGame.Tests.Factories;

public class BombedWallTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new BombedWall(Orientation.HORIZONTAL).GetIcon();
    Assert.Equal("💣", icon);
  }
}