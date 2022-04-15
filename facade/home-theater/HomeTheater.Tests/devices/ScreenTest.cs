using HomeTheater.ConnectedDevices;
using Xunit;

namespace HomeTheater.Tests.ConnectedDevices;

public class ScreenTest
{
  [Fact]
  public void TestUp()
  {
    var screen = new Screen();
    screen.Up();
    Assert.Equal(ScreenPosition.Up, screen.Position);
  }

  [Fact]
  public void TestDown()
  {
    var screen = new Screen();
    screen.Down();
    Assert.Equal(ScreenPosition.Down, screen.Position);
  }
}