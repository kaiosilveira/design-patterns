using Xunit;
using AbstractFactoryPattern.MazeItems.Enchanted;

namespace AbstractFactoryPattern.Tests.Factories;

public class EnchantedDoorTest
{
  [Fact]
  public void TestReturnCorrectIcon()
  {
    var icon = new EnchantedDoor().GetIcon();
    Assert.Equal("🪞", icon);
  }
}