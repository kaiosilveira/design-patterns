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
    Console.WriteLine("Top-O-Line projector on");
    this.IsOn = true;
  }

  public void Off()
  {
    Console.WriteLine("Top-O-Line projector off");
    this.IsOn = false;
  }

  public void WideScreenMode()
  {
    Console.WriteLine("Top-O-Line projector in widescreen mode (16x 9 aspect ratio)");
    this.ScreenMode = ScreenMode.Wide;
  }

  public void TvMode()
  {
    this.ScreenMode = ScreenMode.TV;
  }
}
