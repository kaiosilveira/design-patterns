using MightyGumball.Domain.Machine;
using Xunit;

public class GumballMachineTest
{
  [Fact]
  public void TestReleaseGumball()
  {
    var machine = new GumballMachine(gumballCount: 1);
    machine.ReleaseGumball();
    Assert.Equal(0, machine.GumballCount);
  }
}