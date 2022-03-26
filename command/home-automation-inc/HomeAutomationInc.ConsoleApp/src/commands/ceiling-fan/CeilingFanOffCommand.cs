using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class CeilingFanOffCommand : Command
{
  public CeilingFan ceilingFan { get; private set; }

  public CeilingFanOffCommand(CeilingFan ceilingFan)
  {
    this.ceilingFan = ceilingFan;
  }

  public void Execute()
  {
    this.ceilingFan.Off();
  }

  public void Undo()
  {
    this.ceilingFan.On();
  }

  public string GetName()
  {
    return "CeilingFanOffCommand";
  }
}