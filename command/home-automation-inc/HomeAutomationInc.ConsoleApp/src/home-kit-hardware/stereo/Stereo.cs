using HomeAutomationInc.Hardware.AttachableItems;
using HomeAutomationInc.Hardware.StereoInfo;

namespace HomeAutomationInc.Hardware;

public class Stereo : Switchable
{
  public StereoPlayingMode PlayingMode { get; private set; }
  public bool IsOn { get; private set; }
  public string NowPlaying { get; private set; }
  public string RadioFrequency { get; private set; }
  public int Volume { get; private set; }

  private CD _cd;
  public CD CD
  {
    get => this._cd;
    set
    {
      this._cd = value;
      this.NowPlaying = value.Title;
      this.PlayingMode = StereoPlayingMode.CD;
    }
  }

  private DVD _dvd;
  public DVD DVD
  {
    get => this._dvd;
    set
    {
      this._dvd = value;
    }
  }

  public Stereo()
  {
    this.NowPlaying = "Not Playing";
    this._cd = new CD("No CD");
    this._dvd = new DVD("No DVD");
    this.RadioFrequency = "0.0";
  }

  public void On()
  {
    this.IsOn = true;
  }

  public void Off()
  {
    this.IsOn = false;
  }

  public void AttachCD(CD cd)
  {
    this.PlayingMode = StereoPlayingMode.CD;
    this.CD = cd;
    this.NowPlaying = cd.Title;
  }

  public void AttachDVD(DVD dvd)
  {
    this.PlayingMode = StereoPlayingMode.DVD;
    this.DVD = dvd;
    this.NowPlaying = dvd.Title;
  }

  public void SetRadio(string frequency)
  {
    this.PlayingMode = StereoPlayingMode.RADIO;
    this.RadioFrequency = frequency;
    this.NowPlaying = $"Radio: {frequency}";
  }

  public void SetVolume(int level)
  {
    this.Volume = level;
  }
}