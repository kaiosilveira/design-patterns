using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class CeilingFanOnCommand : Command
{
  public CeilingFan ceilingFan { get; private set; }

  public CeilingFanOnCommand(CeilingFan ceilingFan)
  {
    this.ceilingFan = ceilingFan;
  }

  public void Execute()
  {
    this.ceilingFan.On();
  }
  public void Undo()
  {
    this.ceilingFan.Off();
  }

  public string GetName()
  {
    return "CeilingFanOnCommand";
  }

}