using MightyGumball.Domain.GumballMachineStates;

namespace MightyGumball.Domain.Machine;

public class GumballMachine
{
  public int GumballCount { get; private set; }
  public GumballMachineState NoQuarter { get; private set; }
  public GumballMachineState HasQuarter { get; private set; }
  protected GumballMachineState state;

  public GumballMachine(int gumballCount)
  {
    this.GumballCount = gumballCount;

    this.NoQuarter = new NoQuarterState(this);
    this.HasQuarter = new HasQuarterState(this);

    this.state = this.NoQuarter;
  }

  public void SetState(GumballMachineState state)
  {
    this.state = state;
  }
}