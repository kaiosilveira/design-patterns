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
    throw new NotImplementedException();
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