using Xunit;
using MightyGumball.DomainTests.Machine;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.Domain.Exceptions;

public class SoldOutStateTest
{
  [Fact]
  public void TestInsertQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new SoldOutState(machine);

    Assert.Throws<MachineOutOfGumballsException>(() => state.InsertQuarter());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new SoldOutState(machine);

    Assert.Throws<NoQuarterInsertedException>(() => state.EjectQuarter());
  }

  [Fact]
  public void TestTurnCrank()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new SoldOutState(machine);

    Assert.Throws<NoQuarterInsertedException>(() => state.TurnCrank());
  }

  [Fact]
  public void TestDispense()
  {
    var machine = new TestingGumballMachine(gumballCount: 5);
    var state = new SoldOutState(machine);

    Assert.Throws<NoGumballDispensedException>(() => state.Dispense());
  }
}