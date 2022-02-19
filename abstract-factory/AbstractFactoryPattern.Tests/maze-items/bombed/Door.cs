using Xunit;
using AbstractFactoryPattern.MazeItems.Bombed;

namespace AbstractFactoryPattern.Tests.Factories;

public class BombedDoorTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new BombedDoor().GetIcon();
    Assert.Equal("🪟", icon);
  }
}