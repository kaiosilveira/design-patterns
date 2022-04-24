using Xunit;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;
using MightyGumball.Domain.Exceptions;

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

  [Fact]
  public void TestEjectQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new NoQuarterState(machine);
    Assert.Throws<NoQuarterInsertedException>(() => state.EjectQuarter());
  }

  [Fact]
  public void TestTurnCrank()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new NoQuarterState(machine);
    Assert.Throws<NoQuarterInsertedException>(() => state.TurnCrank());
  }
}