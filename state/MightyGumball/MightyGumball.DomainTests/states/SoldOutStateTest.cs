using Xunit;
using MightyGumball.DomainTests.Machine;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.Domain.Exceptions;

public class SoldOutStateTest
{
  private TestingGumballMachine machine;
  private SoldOutState state;

  public SoldOutStateTest()
  {
    this.machine = new TestingGumballMachine(gumballCount: 0);
    this.state = new SoldOutState(machine);
  }

  [Fact]
  public void TestInsertQuarter()
  {
    Assert.Throws<MachineOutOfGumballsException>(() => this.state.InsertQuarter());
  }

  [Fact]
  public void TestEjectQuarter()
  {
    Assert.Throws<NoQuarterInsertedException>(() => this.state.EjectQuarter());
  }

  [Fact]
  public void TestTurnCrank()
  {
    Assert.Throws<NoQuarterInsertedException>(() => this.state.TurnCrank());
  }

  [Fact]
  public void TestDispense()
  {
    Assert.Throws<NoGumballDispensedException>(() => this.state.Dispense());
  }
}