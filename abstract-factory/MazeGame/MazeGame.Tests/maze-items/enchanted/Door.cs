using Xunit;
using MazeGame.MazeItems.Enchanted;

namespace MazeGame.Tests.Factories;

public class EnchantedDoorTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new EnchantedDoor().GetIcon();
    Assert.Equal("🪞", icon);
  }
}