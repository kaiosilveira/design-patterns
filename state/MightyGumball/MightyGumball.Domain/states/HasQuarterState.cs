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
    Console.WriteLine("Quarter ejected");
    this.gumballMachine.SetState(this.gumballMachine.NoQuarter);
  }

  public void TurnCrank()
  {
    Console.WriteLine("You have turned the crank");
    this.gumballMachine.SetState(this.gumballMachine.Sold);
  }

  public void Dispense()
  {
    throw new NoGumballDispensedException();
  }
}