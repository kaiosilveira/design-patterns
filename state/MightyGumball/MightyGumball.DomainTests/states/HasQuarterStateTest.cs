using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;
using Xunit;

public class HasQuarterStateTest
{
  [Fact]
  public void TestInsertQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new HasQuarterState(machine);
    Assert.Throws<QuarterAlreadyInsertedException>(() => state.InsertQuarter());
  }
}