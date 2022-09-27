using Xunit;
using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;

public class CeilingFanOnCommandTest
{
  [Fact]
  public void TestGetName()
  {
    var ceilingFan = new CeilingFan();
    var cmd = new CeilingFanOnCommand(ceilingFan);

    Assert.Equal("CeilingFanOnCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var ceilingFan = new CeilingFan();
    var cmd = new CeilingFanOnCommand(ceilingFan);

    cmd.Execute();

    Assert.True(ceilingFan.IsOn);
  }

  [Fact]
  public void TestUndo()
  {
    var ceilingFan = new CeilingFan();
    var cmd = new CeilingFanOnCommand(ceilingFan);

    cmd.Execute();
    Assert.True(ceilingFan.IsOn);

    cmd.Undo();
    Assert.False(ceilingFan.IsOn);
  }
}