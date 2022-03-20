using Xunit;
using MazeGame.MazeItems.Enchanted;
using MazeGame.Enumerators;

namespace MazeGame.Tests.Factories;

public class EnchantedWallTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new EnchantedWall(Orientation.HORIZONTAL).GetIcon();
    Assert.Equal("✨", icon);
  }
}