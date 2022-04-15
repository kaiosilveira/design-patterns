namespace HomeTheater.ConnectedDevices;

public enum MediaPlayingState
{
  Playing,
  Paused,
  Stopped
}

public class DVDPlayer : Switchable
{
  public bool IsOn { get; private set; }
  public MediaPlayingState PlayingState { get; private set; }

  public void On()
  {
    Console.WriteLine("DvdPlayer is on");
    this.IsOn = true;
  }

  public void Off()
  {
    Console.WriteLine("DvdPlayer is off");
    this.IsOn = false;
  }

  public void Play()
  {
    this.PlayingState = MediaPlayingState.Playing;
  }

  public void Pause()
  {
    this.PlayingState = MediaPlayingState.Paused;
  }

  public void Stop()
  {
    this.PlayingState = MediaPlayingState.Stopped;
  }
}
