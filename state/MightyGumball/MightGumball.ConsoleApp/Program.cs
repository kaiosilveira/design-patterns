using MightyGumball.Domain.Machine;

namespace MightyGumball.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var machine = new GumballMachine(gumballCount: 3);
    machine.InsertQuarter();
    machine.TurnCrank();
  }
}