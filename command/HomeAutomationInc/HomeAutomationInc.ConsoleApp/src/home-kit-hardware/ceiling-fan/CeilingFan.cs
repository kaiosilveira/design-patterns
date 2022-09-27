using HomeAutomationInc.Hardware.CeilingFanConfig;

namespace HomeAutomationInc.Hardware;

public class CeilingFan : Switchable
{
  public CeilingFanSpeed Speed { get; private set; }
  public bool IsOn { get; private set; }

  public void SetSpeed(CeilingFanSpeed speed)
  {
    this.Speed = speed;
  }

  public void On()
  {
    this.IsOn = true;
    this.Speed = CeilingFanSpeed.MEDIUM;
  }

  public void Off()
  {
    this.IsOn = false;
  }
}