using HomeAutomationInc.Hardware;
using Xunit;

public class GarageDoorTest
{
  [Fact]
  public void TestOpen()
  {
    var garageDoor = new GarageDoor();
    garageDoor.Up();
    Assert.True(garageDoor.IsOpen);
  }

  [Fact]
  public void TestUp()
  {
    var garageDoor = new GarageDoor();
    garageDoor.Up();
    garageDoor.Down();
    Assert.False(garageDoor.IsOpen);
  }
}