using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class HasQuarterState : GumballMachineState
{
  private GumballMachine gumballMachine;

  public HasQuarterState(GumballMachine machine)
  {
    this.gumballMachine = machine;
  }

  public void InsertQuarter()
  {
    throw new QuarterAlreadyInsertedException();
  }

  public void EjectQuarter()
  {
    throw new NotImplementedException();
  }

  public void TurnCrank()
  {
    throw new NotImplementedException();
  }

  public void Dispense()
  {
    throw new NotImplementedException();
  }
}