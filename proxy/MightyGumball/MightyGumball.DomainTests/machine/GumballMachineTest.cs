using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.Domain.Machine;
using MightyGumball.DomainTests.Machine;
using Xunit;

public class GumballMachineTest
{
  [Fact]
  public void TestReleaseGumball()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 1);
    machine.ReleaseGumball();
    Assert.Equal(0, machine.GumballCount);
  }

  [Fact]
  public void TestRefill()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 0);

    machine.Refill(numberOfGumballs: 10);

    Assert.Equal(10, machine.GumballCount);
    Assert.IsType<NoQuarterState>(machine.GetState());
  }
}