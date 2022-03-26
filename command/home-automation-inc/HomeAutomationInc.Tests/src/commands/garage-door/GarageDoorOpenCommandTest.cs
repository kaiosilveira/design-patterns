using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;
using Xunit;

public class GarageDoorOpenCommandTest
{
  [Fact]
  public void TestName()
  {
    var door = new GarageDoor();
    var cmd = new GarageDoorOpenCommand(door);
    Assert.Equal("GarageDoorOpenCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var door = new GarageDoor();
    var cmd = new GarageDoorOpenCommand(door);
    cmd.Execute();

    Assert.True(door.IsOpen);
  }

  [Fact]
  public void TestUndo()
  {
    var door = new GarageDoor();
    var cmd = new GarageDoorOpenCommand(door);

    cmd.Execute();
    Assert.True(door.IsOpen);

    cmd.Undo();
    Assert.False(door.IsOpen);
  }
}