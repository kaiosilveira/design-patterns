using Xunit;
using HomeTheater.ConnectedDevices;

namespace HomeTheater.Tests.ConnectedDevices;

public class DVDPlayerTest
{
  [Fact]
  public void TestOn()
  {
    var dvdPlayer = new DVDPlayer();
    dvdPlayer.On();
    Assert.True(dvdPlayer.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var dvdPlayer = new DVDPlayer();
    dvdPlayer.On();
    dvdPlayer.Off();
    Assert.False(dvdPlayer.IsOn);
  }

  [Fact]
  public void TestPlay()
  {
    var movieTitle = "Fight Club";
    var dvdPlayer = new DVDPlayer();

    dvdPlayer.On();
    dvdPlayer.Play(movieTitle);

    Assert.Equal(movieTitle, dvdPlayer.NowPlaying);
    Assert.Equal(MediaPlayingState.Playing, dvdPlayer.PlayingState);
  }

  [Fact]
  public void TestPause()
  {
    var dvdPlayer = new DVDPlayer();
    dvdPlayer.On();
    dvdPlayer.Pause();
    Assert.Equal(MediaPlayingState.Paused, dvdPlayer.PlayingState);
  }

  [Fact]
  public void TestStop()
  {
    var dvdPlayer = new DVDPlayer();
    dvdPlayer.On();
    dvdPlayer.Stop();
    Assert.Equal(MediaPlayingState.Stopped, dvdPlayer.PlayingState);
  }

  [Fact]
  public void TestEject()
  {
    var dvdPlayer = new DVDPlayer();

    dvdPlayer.On();
    dvdPlayer.Eject();

    Assert.False(dvdPlayer.HasDisk);
    Assert.Equal("", dvdPlayer.NowPlaying);
  }
}