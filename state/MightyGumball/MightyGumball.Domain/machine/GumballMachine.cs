using MightyGumball.Domain.GumballMachineStates;

namespace MightyGumball.Domain.Machine;

public class GumballMachine
{
  public int GumballCount { get; private set; }
  public GumballMachineState NoQuarter { get; private set; }
  public GumballMachineState HasQuarter { get; private set; }
  public GumballMachineState Sold { get; private set; }
  public GumballMachineState SoldOut { get; private set; }
  public WinnerState Winner { get; private set; }
  protected GumballMachineState state;

  public GumballMachine(int gumballCount, int winningChance = 10)
  {
    this.GumballCount = gumballCount;

    this.NoQuarter = new NoQuarterState(machine: this);
    this.HasQuarter = new HasQuarterState(machine: this, winningChance);
    this.Sold = new SoldState(machine: this);
    this.SoldOut = new SoldOutState(machine: this);
    this.Winner = new WinnerState(machine: this);

    this.state = this.NoQuarter;
  }

  public void SetState(GumballMachineState state)
  {
    this.state = state;
  }

  public void ReleaseGumball()
  {
    this.GumballCount--;
  }

  public void InsertQuarter()
  {
    this.state.InsertQuarter();
  }

  public void TurnCrank()
  {
    try
    {
      this.state.TurnCrank();
      this.state.Dispense();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }

  public void EjectQuarter()
  {
    this.state.EjectQuarter();
  }
}