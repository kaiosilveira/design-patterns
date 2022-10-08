using Xunit;
using HomeTheater.ConnectedDevices;

namespace HomeTheater.Tests.ConnectedDevices;

public class ProjectorTest
{
  [Fact]
  public void TestOn()
  {
    var projector = new Projector();
    projector.On();
    Assert.True(projector.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var projector = new Projector();
    projector.Off();
    Assert.False(projector.IsOn);
  }

  [Fact]
  public void TestWideScreenMode()
  {
    var projector = new Projector();
    projector.On();
    projector.WideScreenMode();
    Assert.Equal(ScreenMode.Wide, projector.ScreenMode);
  }

  [Fact]
  public void TestTVMode()
  {
    var projector = new Projector();
    projector.On();
    projector.TvMode();
    Assert.Equal(ScreenMode.TV, projector.ScreenMode);
  }
}