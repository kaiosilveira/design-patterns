using Xunit;
using HomeAutomationInc.Hardware;
using HomeAutomationInc.Hardware.AttachableItems;
using HomeAutomationInc.Hardware.StereoInfo;

public class StereoTest
{
  [Fact]
  public void TestStartsAsOff()
  {
    var stereo = new Stereo();
    Assert.False(stereo.IsOn);
  }

  [Fact]
  public void TestStartsWithNothingPlayingWhenTurnedOn()
  {
    var stereo = new Stereo();
    stereo.On();
    Assert.Equal("Not Playing", stereo.NowPlaying);
  }

  [Fact]
  public void TestSetOn()
  {
    var stereo = new Stereo();
    stereo.On();
    Assert.True(stereo.IsOn);
  }

  [Fact]
  public void TestSetOff()
  {
    var stereo = new Stereo();
    stereo.On();

    stereo.Off();

    Assert.False(stereo.IsOn);
  }

  [Fact]
  public void TestSetCD()
  {
    var cd = new CD(title: "DAMN, by Kendrick Lamar");
    var stereo = new Stereo();
    stereo.On();

    stereo.AttachCD(cd);

    Assert.Equal(StereoPlayingMode.CD, stereo.PlayingMode);
    Assert.Equal(cd.Title, stereo.NowPlaying);
  }

  [Fact]
  public void TestSetDVD()
  {
    var dvd = new DVD(title: "Avengers: Endgame");
    var stereo = new Stereo();
    stereo.On();

    stereo.AttachDVD(dvd);

    Assert.Equal(StereoPlayingMode.DVD, stereo.PlayingMode);
    Assert.Equal(dvd.Title, stereo.NowPlaying);
  }

  [Fact]
  public void TestSetRadio()
  {
    var stereo = new Stereo();
    stereo.On();

    stereo.SetRadio(frequency: "93.6");

    Assert.Equal(StereoPlayingMode.RADIO, stereo.PlayingMode);
    Assert.Equal($"Radio: {stereo.RadioFrequency}", stereo.NowPlaying);
  }

  [Fact]
  public void TestSetVolume()
  {
    var expectedVolume = 11;
    var stereo = new Stereo();
    stereo.On();

    stereo.SetVolume(expectedVolume);

    Assert.Equal(expectedVolume, stereo.Volume);
  }
}