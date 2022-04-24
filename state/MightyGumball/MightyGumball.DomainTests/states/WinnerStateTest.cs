using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;
using Xunit;

public class WinnerStateTest
{
  private TestingGumballMachine machine;
  private WinnerState state;

  public WinnerStateTest()
  {
    this.machine = new TestingGumballMachine(gumballCount: 5);
    this.state = new WinnerState(this.machine);
  }

  [Fact]
  public void TestInsertQuarter()
  {
    Assert.Throws<GumballBeingSoldException>(() => this.state.InsertQuarter());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    Assert.Throws<CrankAlreadyTurnedException>(() => this.state.EjectQuarter());
  }

  [Fact]
  public void TestTurnCrank()
  {
    Assert.Throws<CrankAlreadyTurnedException>(() => this.state.TurnCrank());
  }

  [Fact]
  public void TestDispense()
  {
    this.state.Dispense();
    Assert.Equal(4, this.machine.GumballCount);
    Assert.IsType<NoQuarterState>(this.machine.GetState());
  }

  [Fact]
  public void TestDispenseLastGumball()
  {
    var machineWithOneGumball = new TestingGumballMachine(gumballCount: 1);
    var state = new WinnerState(machineWithOneGumball);

    state.Dispense();

    Assert.Equal(0, machineWithOneGumball.GumballCount);
    Assert.IsType<SoldOutState>(machineWithOneGumball.GetState());
  }

  [Fact]
  public void TestThrowsIfNoGumballsAvailable()
  {
    var machineOutOfGumballs = new TestingGumballMachine(gumballCount: 0);
    var state = new WinnerState(machineOutOfGumballs);

    Assert.Throws<MachineOutOfGumballsException>(() => state.Dispense());
  }
}