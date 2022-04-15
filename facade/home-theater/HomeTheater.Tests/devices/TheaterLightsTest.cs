using Xunit;
using HomeTheater.ConnectedDevices;

namespace HomeTheater.Tests.ConnectedDevices;

public class TheaterLightsTest
{
  [Fact]
  public void TestOn()
  {
    var theaterLights = new TheaterLights();
    theaterLights.On();
    Assert.True(theaterLights.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var theaterLights = new TheaterLights();
    theaterLights.Off();
    Assert.False(theaterLights.IsOn);
  }

  [Fact]
  public void TestDim()
  {
    var theaterLights = new TheaterLights();
    theaterLights.On();
    theaterLights.Dim(10);
    Assert.Equal(10, theaterLights.Brightness);
  }

  [Fact]
  public void TestCannotDimWhenOff()
  {
    var theaterLights = new TheaterLights();
    Assert.Throws<DeviceOffException>(() => theaterLights.Dim(10));
  }
}