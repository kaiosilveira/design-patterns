using ExpensiveMath.Algorithms;

namespace ExpensiveMath.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var ui = new MathUI(new SieveOfEratosthenesProxy(
      calculator: new SieveOfEratosthenesCalculator()
    ));

    ui.Run();
  }
}