using MightyGumball.Domain.Machine;

namespace MightyGumball.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var machine = new GumballMachine(gumballCount: 50);

    for (int i = 0; i < 10; i++)
    {
      machine.InsertQuarter();
      machine.TurnCrank();
    }
  }
}