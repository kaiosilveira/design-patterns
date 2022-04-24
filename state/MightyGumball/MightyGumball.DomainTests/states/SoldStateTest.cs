using Xunit;
using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.DomainTests.Machine;

public class SoldStateTest
{
  private TestingGumballMachine machine;
  private SoldState state;

  public SoldStateTest()
  {
    this.machine = new TestingGumballMachine();
    this.state = new SoldState(machine);
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
    var state = new SoldState(machineWithOneGumball);

    state.Dispense();

    Assert.Equal(0, machineWithOneGumball.GumballCount);
    Assert.IsType<SoldOutState>(machineWithOneGumball.GetState());
  }

  [Fact]
  public void TestThrowsIfNoGumballsAvailable()
  {
    var machineOutOfGumballs = new TestingGumballMachine(gumballCount: 0);
    var state = new SoldState(machineOutOfGumballs);

    Assert.Throws<MachineOutOfGumballsException>(() => state.Dispense());
  }
}