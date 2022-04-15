using Xunit;
using HomeTheater.Facade;
using HomeTheater.ConnectedDevices;

namespace HomeTheater.Tests;

public class HomeTheaterFacadeTest
{
  [Fact]
  public void TestSetupEnvironmentForWatchingMovie()
  {
    var popper = new PopcornPopper();
    var lights = new TheaterLights();
    var screen = new Screen();
    var projector = new Projector();
    var dvd = new DVDPlayer();
    var amp = new Amplifier();

    var homeTheaterFacade = new HomeTheaterFacade(popper, lights, screen, projector, dvd, amp);

    homeTheaterFacade.WatchMovie("Fight Club");

    Assert.True(popper.IsOn);
    Assert.True(popper.Popping);

    Assert.True(projector.IsOn);
    Assert.Equal(ScreenMode.Wide, projector.ScreenMode);

    Assert.True(amp.IsOn);
    Assert.Equal(5, amp.Volume);
    Assert.Equal(SoundMode.Surround, amp.SoundMode);

    Assert.True(dvd.IsOn);

    Assert.True(lights.IsOn);
    Assert.Equal(10, lights.Brightness);

    Assert.Equal(ScreenPosition.Down, screen.Position);
    Assert.Equal(dvd.PlayingState, MediaPlayingState.Playing);
  }

  [Fact]
  public void TestEndMovie()
  {
    var popper = new PopcornPopper();
    var lights = new TheaterLights();
    var screen = new Screen();
    var projector = new Projector();
    var dvd = new DVDPlayer();
    var amp = new Amplifier();

    var homeTheaterFacade = new HomeTheaterFacade(popper, lights, screen, projector, dvd, amp);

    homeTheaterFacade.WatchMovie("Fight Club");
    homeTheaterFacade.EndMovie();

    Assert.False(popper.IsOn);
    Assert.False(popper.Popping);

    Assert.False(projector.IsOn);

    Assert.False(amp.IsOn);

    Assert.False(dvd.IsOn);

    Assert.False(lights.IsOn);

    Assert.Equal(ScreenPosition.Up, screen.Position);
    Assert.Equal(dvd.PlayingState, MediaPlayingState.Stopped);
  }
}