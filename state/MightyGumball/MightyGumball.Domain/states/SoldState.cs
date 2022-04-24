using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class SoldState : GumballMachineState
{
  public GumballMachine gumballMachine;

  public SoldState(GumballMachine machine)
  {
    this.gumballMachine = machine;
  }

  public void InsertQuarter()
  {
    throw new GumballBeingSoldException();
  }

  public void EjectQuarter()
  {
    throw new CrankAlreadyTurnedException();
  }

  public void TurnCrank()
  {
    throw new CrankAlreadyTurnedException();
  }

  public void Dispense()
  {
    if (this.gumballMachine.GumballCount > 1)
    {
      this.gumballMachine.ReleaseGumball();
      this.gumballMachine.SetState(this.gumballMachine.NoQuarter);
    }
    else if (this.gumballMachine.GumballCount == 1)
    {
      this.gumballMachine.ReleaseGumball();
      this.gumballMachine.SetState(this.gumballMachine.SoldOut);
    } else {
      throw new MachineOutOfGumballsException();
    }
  }
}