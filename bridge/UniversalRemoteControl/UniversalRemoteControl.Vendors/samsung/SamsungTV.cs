using UniversalRemoteControl.Domain;

namespace UniversalRemoteControl.Vendors.Samsung;

public class SamsungTV : TV
{
  public bool IsOn { get; private set; }
  public TVChannel CurrentChannel { get; private set; }

  public SamsungTV()
  {
    this.IsOn = false;
    this.CurrentChannel = new NoChannel();
  }

  public void On()
  {
    this.IsOn = true;
  }

  public void Off()
  {
    this.IsOn = false;
  }

  public void TuneChannel(TVChannel channel)
  {
    this.CurrentChannel = channel;
  }
}