using Xunit;
using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;

public class CeilingFanOffCommandTest
{
  [Fact]
  public void TestGetName()
  {
    var ceilingFan = new CeilingFan();
    var cmd = new CeilingFanOffCommand(ceilingFan);

    Assert.Equal("CeilingFanOffCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var ceilingFan = new CeilingFan();
    ceilingFan.On();
    var cmd = new CeilingFanOffCommand(ceilingFan);

    cmd.Execute();

    Assert.False(ceilingFan.IsOn);
  }

  [Fact]
  public void TestUndo()
  {
    var ceilingFan = new CeilingFan();
    ceilingFan.On();
    var cmd = new CeilingFanOffCommand(ceilingFan);

    cmd.Execute();
    Assert.False(ceilingFan.IsOn);

    cmd.Undo();
    Assert.True(ceilingFan.IsOn);
  }
}
