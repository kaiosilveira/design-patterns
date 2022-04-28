using Xunit;
using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;

public class SoldStateTest
{
  [Fact]
  public void TestInsertQuarter()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 5);
    var state = new SoldState(machine);

    Assert.Throws<GumballBeingSoldException>(() => state.InsertQuarter());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 5);
    var state = new SoldState(machine);

    Assert.Throws<CrankAlreadyTurnedException>(() => state.EjectQuarter());
  }

  [Fact]
  public void TestTurnCrank()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 5);
    var state = new SoldState(machine);

    Assert.Throws<CrankAlreadyTurnedException>(() => state.TurnCrank());
  }

  [Fact]
  public void TestDispense()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 5);
    var state = new SoldState(machine);

    state.Dispense();

    Assert.Equal(4, machine.GumballCount);
    Assert.IsType<NoQuarterState>(machine.GetState());
  }

  [Fact]
  public void TestDispenseLastGumball()
  {
    var machineWithOneGumball = new TestingGumballMachine(location: "Lisbon", gumballCount: 1);
    var state = new SoldState(machineWithOneGumball);

    state.Dispense();

    Assert.Equal(0, machineWithOneGumball.GumballCount);
    Assert.IsType<SoldOutState>(machineWithOneGumball.GetState());
  }

  [Fact]
  public void TestThrowsIfNoGumballsAvailable()
  {
    var machineOutOfGumballs = new TestingGumballMachine(location: "Lisbon", gumballCount: 0);
    var state = new SoldState(machineOutOfGumballs);

    Assert.Throws<MachineOutOfGumballsException>(() => state.Dispense());
  }
}