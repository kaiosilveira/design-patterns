using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;
using Xunit;

public class GarageDoorCloseCommandTest
{
  [Fact]
  public void TestName()
  {
    var door = new GarageDoor();
    var cmd = new GarageDoorCloseCommand(door);
    Assert.Equal("GarageDoorCloseCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var door = new GarageDoor();
    door.Up();
    var cmd = new GarageDoorCloseCommand(door);

    cmd.Execute();

    Assert.False(door.IsOpen);
  }

  [Fact]
  public void TestUndo()
  {
    var door = new GarageDoor();
    door.Up();
    var cmd = new GarageDoorCloseCommand(door);

    cmd.Execute();
    Assert.False(door.IsOpen);

    cmd.Undo();
    Assert.True(door.IsOpen);
  }
}