using Xunit;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;
using MightyGumball.Domain.Exceptions;

public class NoQuarterStateTest
{
  private TestingGumballMachine machine;
  private NoQuarterState state;

  public NoQuarterStateTest()
  {
    this.machine = new TestingGumballMachine(gumballCount: 5);
    this.state = new NoQuarterState(machine);
  }

  [Fact]
  public void TestInsertQuarter()
  {
    state.InsertQuarter();
    Assert.IsType<HasQuarterState>(machine.GetState());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    Assert.Throws<NoQuarterInsertedException>(() => state.EjectQuarter());
  }

  [Fact]
  public void TestTurnCrank()
  {
    Assert.Throws<NoQuarterInsertedException>(() => state.TurnCrank());
  }

  [Fact]
  public void TestDispense()
  {
    Assert.Throws<NoQuarterInsertedException>(() => state.Dispense());
  }
}