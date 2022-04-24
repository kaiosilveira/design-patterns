using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.Domain.Machine;

public class SoldOutState : GumballMachineState
{
  private GumballMachine gumballMachine;

  public SoldOutState(GumballMachine machine)
  {
    this.gumballMachine = machine;
  }

  public void InsertQuarter()
  {
    throw new MachineOutOfGumballsException();
  }

  public void EjectQuarter()
  {
    throw new NoQuarterInsertedException();
  }

  public void TurnCrank()
  {
    throw new NoQuarterInsertedException();
  }

  public void Dispense()
  {
    throw new NoGumballDispensedException();
  }
}