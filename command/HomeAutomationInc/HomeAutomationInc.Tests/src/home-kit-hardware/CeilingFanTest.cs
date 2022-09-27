using HomeAutomationInc.Hardware;
using HomeAutomationInc.Hardware.CeilingFanConfig;
using Xunit;

public class CeilingFanTest
{
  [Fact]
  public void TestOn()
  {
    var ceilingFan = new CeilingFan();
    ceilingFan.On();
    Assert.True(ceilingFan.IsOn);
    Assert.Equal(CeilingFanSpeed.MEDIUM, ceilingFan.Speed);
  }

  [Fact]
  public void TestOff()
  {
    var ceilingFan = new CeilingFan();
    ceilingFan.On();
    ceilingFan.Off();

    Assert.False(ceilingFan.IsOn);
  }

  [Fact]
  public void TestSetSpeed()
  {
    var expectedSpeed = CeilingFanSpeed.HIGH;
    var ceilingFan = new CeilingFan();
    ceilingFan.On();
    ceilingFan.SetSpeed(expectedSpeed);

    Assert.Equal(expectedSpeed, ceilingFan.Speed);
  }
}