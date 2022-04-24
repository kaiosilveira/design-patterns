using Xunit;
using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;

public class HasQuarterStateTest
{
  private HasQuarterState state;
  private TestingGumballMachine machine;

  public HasQuarterStateTest()
  {
    this.machine = new TestingGumballMachine(gumballCount: 5);
    this.state = new HasQuarterState(machine);
  }

  [Fact]
  public void TestInsertQuarter()
  {
    Assert.Throws<QuarterAlreadyInsertedException>(() => state.InsertQuarter());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    state.EjectQuarter();
    Assert.IsType<NoQuarterState>(machine.GetState());
  }

  [Fact]
  public void TestTurnCrank()
  {
    state.TurnCrank();
    Assert.IsType<SoldState>(machine.GetState());
  }

  [Fact]
  public void TestDispense()
  {
    Assert.Throws<NoGumballDispensedException>(() => state.Dispense());
  }
}