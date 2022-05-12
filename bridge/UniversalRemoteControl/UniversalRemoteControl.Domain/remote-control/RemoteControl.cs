namespace UniversalRemoteControl.Domain;

public abstract class RemoteControl
{
  protected TV implementor;

  public RemoteControl(TV tv)
  {
    this.implementor = tv;
  }

  public void On()
  {
    this.implementor.On();
  }

  public void Off()
  {
    this.implementor.Off();
  }

  public void SetChannel(TVChannel channel)
  {
    implementor.TuneChannel(channel);
  }
}