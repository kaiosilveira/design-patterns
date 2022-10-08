using Xunit;
using MazeGame.MazeItems.Bombed;

namespace MazeGame.Tests.Factories;

public class BombedDoorTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new BombedDoor().GetIcon();
    Assert.Equal("🪟", icon);
  }
}