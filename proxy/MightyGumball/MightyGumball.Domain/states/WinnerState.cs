using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class WinnerState : GumballMachineState
{
  private GumballMachine gumballMachine;

  public WinnerState(GumballMachine machine)
  {
    this.gumballMachine = machine;
  }

  public void InsertQuarter()
  {
    throw new GumballBeingSoldException();
  }

  public void TurnCrank()
  {
    throw new CrankAlreadyTurnedException();
  }

  public void EjectQuarter()
  {
    throw new CrankAlreadyTurnedException();
  }

  public void Dispense()
  {
    Console.WriteLine("Dispensing gumball");
    if (this.gumballMachine.GumballCount > 1)
    {
      this.gumballMachine.ReleaseGumball();
      this.gumballMachine.SetState(this.gumballMachine.NoQuarter);
    }
    else if (this.gumballMachine.GumballCount == 1)
    {
      this.gumballMachine.ReleaseGumball();
      this.gumballMachine.SetState(this.gumballMachine.SoldOut);
    }
    else
    {
      throw new MachineOutOfGumballsException();
    }
  }
}