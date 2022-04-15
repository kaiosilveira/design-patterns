namespace HomeTheater.ConnectedDevices;

public enum ScreenMode
{
  Wide,
  TV
}

public class Projector : Switchable
{
  public bool IsOn { get; private set; }
  public ScreenMode ScreenMode { get; private set; }

  public void On()
  {
    this.IsOn = true;
  }

  public void Off()
  {
    this.IsOn = false;
  }

  public void WideScreenMode()
  {
    this.ScreenMode = ScreenMode.Wide;
  }

  public void TvMode()
  {
    this.ScreenMode = ScreenMode.TV;
  }
}
