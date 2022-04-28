using Xunit;
using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;

public class HasQuarterStateTest
{
  [Fact]
  public void TestInsertQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 1);
    var state = new HasQuarterState(machine, winningChance: 0);
    Assert.Throws<QuarterAlreadyInsertedException>(() => state.InsertQuarter());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 1);
    var state = new HasQuarterState(machine, winningChance: 0);
    state.EjectQuarter();
    Assert.IsType<NoQuarterState>(machine.GetState());
  }

  [Fact]
  public void TestTurnCrank()
  {
    var machine = new TestingGumballMachine(gumballCount: 1);
    var state = new HasQuarterState(machine, winningChance: 0);

    state.TurnCrank();

    Assert.IsType<SoldState>(machine.GetState());
  }

  [Fact]
  public void TestWinner()
  {
    var machine = new TestingGumballMachine(gumballCount: 1);
    var state = new HasQuarterState(machine, winningChance: 100);

    state.TurnCrank();

    Assert.IsType<WinnerState>(machine.GetState());
  }

  [Fact]
  public void TestDispense()
  {
    var machine = new TestingGumballMachine(gumballCount: 1);
    var state = new HasQuarterState(machine, winningChance: 0);
    Assert.Throws<NoGumballDispensedException>(() => state.Dispense());
  }
}