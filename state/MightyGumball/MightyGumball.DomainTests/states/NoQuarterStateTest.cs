using Xunit;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;

public class NoQuarterStateTest
{
  [Fact]
  public void TestInsertQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new NoQuarterState(machine);
    state.InsertQuarter();
    Assert.IsType<HasQuarterState>(machine.GetState());
  }
}