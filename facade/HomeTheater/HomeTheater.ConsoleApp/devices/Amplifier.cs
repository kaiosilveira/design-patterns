namespace HomeTheater.ConnectedDevices;

public enum SoundMode
{
  Stereo,
  Dolby,
  Surround
}

public class Amplifier : Switchable
{
  public bool IsOn { get; private set; }
  public int Volume { get; private set; }
  public int Tuner { get; private set; }
  public SoundMode SoundMode { get; private set; }
  private DVDPlayer? _dvd { get; set; }

  public void Off()
  {
    Console.WriteLine("Top-O-Line Amplifier off");
    this.IsOn = false;
  }

  public void On()
  {
    Console.WriteLine("Top-O-Line Amplifier on");
    this.IsOn = true;
  }

  public void SetStereoSound()
  {
    this.SoundMode = SoundMode.Stereo;
  }

  public void SetSurroundSound()
  {
    Console.WriteLine("Top-O-Line Amplifier surround sound on (5 speakers, 1 subwoofer)");
    this.SoundMode = SoundMode.Surround;
  }

  public void SetTuner(int Tuner)
  {
    this.Tuner = Tuner;
  }

  public void SetDVD(DVDPlayer dvd)
  {
    Console.WriteLine("Top-O-Line Amplifier setting DVD Player");
    this._dvd = dvd;
  }

  public void SetVolume(int volume)
  {
    Console.WriteLine($"Top-O-Line Amplifier setting volue to {volume}");
    this.Volume = volume;
  }
}
