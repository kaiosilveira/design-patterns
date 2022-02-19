using Xunit;
using AbstractFactoryPattern.MazeItems.Bombed;

namespace AbstractFactoryPattern.Tests.Factories;

public class DoorTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new BombedDoor().GetIcon();
    Assert.Equal("🪟", icon);
  }
}