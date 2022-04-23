
using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class NoQuarterState : GumballMachineState
{
  private GumballMachine gumballMachine;

  public NoQuarterState(GumballMachine machine)
  {
    this.gumballMachine = machine;
  }

  public void InsertQuarter()
  {
    Console.WriteLine("You have inserted a quarter");
    this.gumballMachine.SetState(this.gumballMachine.HasQuarter);
  }
}