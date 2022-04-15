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

  public void Off()
  {
    this.IsOn = false;
  }

  public void On()
  {
    this.IsOn = true;
  }

  public void SetStereoSound()
  {
    this.SoundMode = SoundMode.Stereo;
  }

  public void SetSurroundSound()
  {
    this.SoundMode = SoundMode.Surround;
  }

  public void SetTuner(int Tuner)
  {
    this.Tuner = Tuner;
  }

  public void SetVolume(int volume)
  {
    this.Volume = volume;
  }
}
