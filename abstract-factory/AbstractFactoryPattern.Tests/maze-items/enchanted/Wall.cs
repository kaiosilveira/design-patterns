using Xunit;
using AbstractFactoryPattern.MazeItems.Enchanted;
using AbstractFactoryPattern.Enumerators;

namespace AbstractFactoryPattern.Tests.Factories;

public class EnchantedWallTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new EnchantedWall(Orientation.HORIZONTAL).GetIcon();
    Assert.Equal("✨", icon);
  }
}