namespace ExpensiveMath.Algorithms;

public class SieveOfEratosthenesProxy : SieveOfEratosthenes
{
  private SieveOfEratosthenesCalculator calculator;

  public SieveOfEratosthenesProxy(SieveOfEratosthenesCalculator calculator)
  {
    this.calculator = calculator;
  }

  public void PrintPrimeCountUpTo(int n)
  {
    Console.WriteLine("Processing...");
    var thread = new Thread(() =>
    {
      Console.SetCursorPosition(0, Console.CursorTop);
      Console.Write(new string(' ', Console.WindowWidth));
      Console.SetCursorPosition(0, Console.CursorTop - 1);
      this.calculator.PrintPrimeCountUpTo(n);
    });

    thread.Start();
    thread.Join();
  }
}