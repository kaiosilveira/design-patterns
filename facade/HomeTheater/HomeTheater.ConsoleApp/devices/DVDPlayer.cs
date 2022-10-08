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
  public bool HasDisk { get; private set; }
  public MediaPlayingState PlayingState { get; private set; }
  public string? NowPlaying { get; private set; }

  public void On()
  {
    Console.WriteLine("Top-O-Line DVD player is on");
    this.IsOn = true;
  }

  public void Off()
  {
    Console.WriteLine("Top-O-Line DVD player is off");
    this.IsOn = false;
  }

  public void Play(string name)
  {
    Console.WriteLine($"Top-O-Line DVD player is playing {name}");
    this.NowPlaying = name;
    this.PlayingState = MediaPlayingState.Playing;
  }

  public void Pause()
  {
    Console.WriteLine("Top-O-Line DVD player paused");
    this.PlayingState = MediaPlayingState.Paused;
  }

  public void Stop()
  {
    Console.WriteLine("Top-O-Line DVD player stopped");
    this.PlayingState = MediaPlayingState.Stopped;
  }

  public void Eject()
  {
    Console.WriteLine($"Top-O-Line DVD player ejecting {this.NowPlaying}");
    this.HasDisk = false;
    this.NowPlaying = "";
  }
}
