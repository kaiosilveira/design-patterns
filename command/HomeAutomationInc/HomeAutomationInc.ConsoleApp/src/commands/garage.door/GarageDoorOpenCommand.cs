using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class GarageDoorOpenCommand : Command
{
  private GarageDoor door;

  public GarageDoorOpenCommand(GarageDoor garageDoor)
  {
    this.door = garageDoor;
  }

  public void Execute()
  {
    this.door.Up();
  }

  public void Undo()
  {
    this.door.Down();
  }

  public string GetName()
  {
    return "GarageDoorOpenCommand";
  }
}