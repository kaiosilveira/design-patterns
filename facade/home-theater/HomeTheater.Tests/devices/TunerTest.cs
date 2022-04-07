using Xunit;
using HomeTheater.ConnectedDevices;

public class TunerTest
{
  [Fact]
  public void TestOn()
  {
    var tuner = new Tuner();
    tuner.On();
    Assert.True(tuner.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var tuner = new Tuner();
    tuner.Off();
    Assert.False(tuner.IsOn);
  }

  [Fact]
  public void TestSetAM()
  {
    var tuner = new Tuner();
    tuner.SetAM();
    Assert.Equal(TunerMode.AM, tuner.Mode);
  }

  [Fact]
  public void TestSetFM()
  {
    var tuner = new Tuner();
    tuner.SetFM();
    Assert.Equal(TunerMode.FM, tuner.Mode);
  }

  [Fact]
  public void TestSetFrequency()
  {
    var tuner = new Tuner();
    tuner.SetFrequency(87.5);
    Assert.Equal(87.5, tuner.Frequency);
  }
}