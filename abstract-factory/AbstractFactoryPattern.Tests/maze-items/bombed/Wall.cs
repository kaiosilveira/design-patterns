using Xunit;
using AbstractFactoryPattern.MazeItems.Bombed;
using AbstractFactoryPattern.Enumerators;

namespace AbstractFactoryPattern.Tests.Factories;

public class BombedWallTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new BombedWall(Orientation.HORIZONTAL).GetIcon();
    Assert.Equal("💣", icon);
  }
}