using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class HasQuarterState : GumballMachineState
{
  private GumballMachine gumballMachine;

  public HasQuarterState(GumballMachine machine)
  {
    this.gumballMachine = machine;
  }

  public void Dispense()
  {
    throw new NotImplementedException();
  }

  public void EjectQuarter()
  {
    throw new NotImplementedException();
  }

  public void InsertQuarter()
  {
    throw new NotImplementedException();
  }

  public void TurnCrank()
  {
    throw new NotImplementedException();
  }
}