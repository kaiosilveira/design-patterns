using Xunit;
using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.MazeItems;

namespace AbstractFactoryPattern.Tests.Factories;

public class WallTest
{
  [Fact]
  public void TestReturnCorrectHorizontalIcon()
  {
    var icon = new Wall(Orientation.HORIZONTAL).GetIcon();
    Assert.Equal("--", icon);
  }

  public void TestReturnCorrectVerticalIcon()
  {
    var icon = new Wall(Orientation.VERTICAL).GetIcon();
    Assert.Equal("|", icon);
  }
}