using Xunit;
using HomeTheater.ConnectedDevices;

namespace HomeTheater.Tests.ConnectedDevices;

public class AmplifierTest
{
  [Fact]
  public void TesOn()
  {
    var amplifier = new Amplifier();
    amplifier.On();
    Assert.True(amplifier.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var amplifier = new Amplifier();
    amplifier.Off();
    Assert.False(amplifier.IsOn);
  }

  [Fact]
  public void TestSetStereo()
  {
    var amplifier = new Amplifier();
    amplifier.On();
    amplifier.SetStereoSound();
    Assert.Equal(SoundMode.Stereo, amplifier.SoundMode);
  }

  [Fact]
  public void TestSetSurround()
  {
    var amplifier = new Amplifier();
    amplifier.On();
    amplifier.SetSurroundSound();
    Assert.Equal(SoundMode.Surround, amplifier.SoundMode);
  }

  [Fact]
  public void TestSetVolume()
  {
    var amplifier = new Amplifier();
    amplifier.On();
    amplifier.SetVolume(10);
    Assert.Equal(10, amplifier.Volume);
  }

  [Fact]
  public void TestSetTuner()
  {
    var amplifier = new Amplifier();
    amplifier.On();
    amplifier.SetTuner(10);
    Assert.Equal(10, amplifier.Tuner);
  }
}