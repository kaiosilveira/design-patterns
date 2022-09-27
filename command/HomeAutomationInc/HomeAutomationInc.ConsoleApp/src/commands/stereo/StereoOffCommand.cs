using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Commands;

public class StereoOffCommand : Command
{
  private Stereo stereo;
  public StereoOffCommand(Stereo stereo)
  {
    this.stereo = stereo;
  }

  public void Execute()
  {
    this.stereo.Off();
  }

  public void Undo()
  {
    this.stereo.On();
  }

  public string GetName()
  {
    return "StereoOffCommand";
  }
}