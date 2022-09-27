using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class GarageDoorCloseCommand : Command
{
  private GarageDoor door;

  public GarageDoorCloseCommand(GarageDoor garageDoor)
  {
    this.door = garageDoor;
  }

  public void Execute()
  {
    this.door.Down();
  }

  public void Undo()
  {
    this.door.Up();
  }

  public string GetName()
  {
    return "GarageDoorCloseCommand";
  }

}