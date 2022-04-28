using MightyGumball.Domain.Exceptions;
using MightyGumball.Domain.Machine;

namespace MightyGumball.Domain.GumballMachineStates;

public class HasQuarterState : GumballMachineState
{
  private Random randomWinnerGenerator;
  private GumballMachine gumballMachine;
  private int winningChance;

  public HasQuarterState(GumballMachine machine, int winningChance = 10)
  {
    this.gumballMachine = machine;
    this.winningChance = winningChance;
    this.randomWinnerGenerator = new Random();
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
    var randomNumber = this.randomWinnerGenerator.Next(0, 100);
    var isWinner = randomNumber <= this.winningChance;
    Console.WriteLine("You have turned the crank");
    Console.WriteLine($"Is winner? {isWinner}");

    if (isWinner)
    {
      this.gumballMachine.SetState(this.gumballMachine.Winner);
    }
    else
    {
      this.gumballMachine.SetState(this.gumballMachine.Sold);
    }
  }

  public void Dispense()
  {
    throw new NoGumballDispensedException();
  }
}