using Xunit;
using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;

public class LightOffCommandTest
{
  [Fact]
  public void TestName()
  {
    var light = new Light();
    var cmd = new LightOffCommand(light);
    Assert.Equal("LightOffCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var light = new Light();
    var cmd = new LightOffCommand(light);
    light.On();

    cmd.Execute();

    Assert.False(light.IsOn);
  }

  [Fact]
  public void TestUndo()
  {
    var light = new Light();
    var cmd = new LightOffCommand(light);
    light.On();

    cmd.Execute();
    Assert.False(light.IsOn);

    cmd.Undo();
    Assert.True(light.IsOn);
  }
}