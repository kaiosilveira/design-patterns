using Xunit;
using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;

public class StereoOffCommandTest
{
  [Fact]
  public void TestExecute()
  {
    var stereo = new Stereo();
    stereo.On();

    var cmd = new StereoOffCommand(stereo);
    cmd.Execute();

    Assert.False(stereo.IsOn);
  }

  [Fact]
  public void TestUndo()
  {
    var stereo = new Stereo();
    stereo.On();

    var cmd = new StereoOffCommand(stereo);

    cmd.Execute();
    Assert.False(stereo.IsOn);

    cmd.Undo();
    Assert.True(stereo.IsOn);
  }
}