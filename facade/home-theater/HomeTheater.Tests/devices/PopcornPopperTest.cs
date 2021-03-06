using Xunit;
using HomeTheater.ConnectedDevices;

namespace HomeTheater.Tests.ConnectedDevices;

public class PopcornPopperTest
{
  [Fact]
  public void TestOn()
  {
    var popper = new PopcornPopper();
    popper.On();
    Assert.True(popper.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var popper = new PopcornPopper();
    popper.Off();
    Assert.False(popper.IsOn);
    Assert.False(popper.Popping);
  }

  [Fact]
  public void TestPop()
  {
    var popper = new PopcornPopper();
    popper.Pop();
    Assert.True(popper.Popping);
  }
}