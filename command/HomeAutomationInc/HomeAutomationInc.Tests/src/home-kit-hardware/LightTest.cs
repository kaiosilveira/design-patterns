using Xunit;
using HomeAutomationInc.Hardware;

public class LightTest
{
  [Fact]
  public void TestOn()
  {
    var light = new Light();
    light.On();
    Assert.True(light.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var light = new Light();
    light.On();
    light.Off();
    Assert.False(light.IsOn);
  }
}