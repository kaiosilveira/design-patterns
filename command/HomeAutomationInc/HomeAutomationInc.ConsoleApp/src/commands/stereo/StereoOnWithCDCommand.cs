using HomeAutomationInc.Hardware;
using HomeAutomationInc.Hardware.AttachableItems;

namespace HomeAutomationInc.Commands;

public class StereoOnWithCDCommand : Command
{
  private Stereo stereo;

  public StereoOnWithCDCommand(Stereo stereo)
  {
    this.stereo = stereo;
  }

  public void Execute()
  {
    this.stereo.On();
    this.stereo.SetVolume(11);
    this.stereo.AttachCD(new CD(title: "Good Kid, M.a.a.d City — Kendrick Lamar"));
  }

  public void Undo()
  {
    this.stereo.Off();
  }

  public string GetName()
  {
    return "StereoOnWithCDCommand";
  }
}