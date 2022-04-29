using ExpensiveMath.Algorithms;

namespace ExpensiveMath.ConsoleApp;

public class MathUI
{
  private SieveOfEratosthenes calculator;

  public MathUI(SieveOfEratosthenes calculator)
  {
    this.calculator = calculator;
  }

  public void Run()
  {
    Console.WriteLine("Type the number you want to print primes up to:");
    Console.Write("> ");
    var limit = Convert.ToInt32(Console.ReadLine());
    this.calculator.PrintPrimeCountUpTo(limit);
  }
}