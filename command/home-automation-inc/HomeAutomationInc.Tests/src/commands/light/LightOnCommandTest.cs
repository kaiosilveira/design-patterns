using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;
using Xunit;

public class LightOnCommandTest
{
  [Fact]
  public void TestName()
  {
    var light = new Light();
    var cmd = new LightOnCommand(light);
    Assert.Equal("LightOnCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var light = new Light();
    var cmd = new LightOnCommand(light);
    cmd.Execute();
    Assert.True(light.IsOn);
  }

  [Fact]
  public void TestUndo()
  {
    var light = new Light();
    var cmd = new LightOnCommand(light);

    cmd.Execute();
    Assert.True(light.IsOn);

    cmd.Undo();
    Assert.False(light.IsOn);
  }
}