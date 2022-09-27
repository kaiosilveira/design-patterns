using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class LightOnCommand : Command
{
  private Light light;

  public LightOnCommand(Light light)
  {
    this.light = light;
  }

  public void Execute()
  {
    this.light.On();
  }

  public void Undo()
  {
    this.light.Off();
  }

  public string GetName()
  {
    return "LightOnCommand";
  }
}