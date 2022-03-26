using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class LightOffCommand : Command
{
  private Light light;

  public LightOffCommand(Light light)
  {
    this.light = light;
  }

  public void Execute()
  {
    this.light.Off();
  }

  public void Undo()
  {
    this.light.On();
  }

  public string GetName()
  {
    return "LightOffCommand";
  }
}