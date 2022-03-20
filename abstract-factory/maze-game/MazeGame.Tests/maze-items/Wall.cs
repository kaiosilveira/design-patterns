using Xunit;
using MazeGame.Enumerators;
using MazeGame.MazeItems;

namespace MazeGame.Tests.Factories;

public class WallTest
{
  [Fact]
  public void TestReturnCorrectHorizontalIcon()
  {
    var icon = new Wall(Orientation.HORIZONTAL).GetIcon();
    Assert.Equal("--", icon);
  }

  [Fact]
  public void TestReturnCorrectVerticalIcon()
  {
    var icon = new Wall(Orientation.VERTICAL).GetIcon();
    Assert.Equal("|", icon);
  }
}