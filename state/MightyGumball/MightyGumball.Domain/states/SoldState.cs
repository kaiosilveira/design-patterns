using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class SoldState : GumballMachineState
{
  public GumballMachine gumballMachine;

  public SoldState(GumballMachine machine)
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