using Xunit;
using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;
using HomeAutomationInc.Hardware.StereoInfo;

public class StereoOnWithCdCommandTest
{
  [Fact]
  public void TestGetName()
  {
    var stereo = new Stereo();
    var cmd = new StereoOnWithCDCommand(stereo);

    Assert.Equal("StereoOnWithCDCommand", cmd.GetName());
  }

  [Fact]
  public void TestExecute()
  {
    var stereo = new Stereo();
    var cmd = new StereoOnWithCDCommand(stereo);

    cmd.Execute();

    Assert.True(stereo.IsOn);
    Assert.Equal(11, stereo.Volume);
    Assert.Equal(StereoPlayingMode.CD, stereo.PlayingMode);
  }

  [Fact]
  public void TestUndo()
  {
    var stereo = new Stereo();
    var cmd = new StereoOnWithCDCommand(stereo);

    cmd.Execute();
    Assert.True(stereo.IsOn);
    Assert.Equal(11, stereo.Volume);
    Assert.Equal(StereoPlayingMode.CD, stereo.PlayingMode);

    cmd.Undo();
    Assert.False(stereo.IsOn);
  }
}