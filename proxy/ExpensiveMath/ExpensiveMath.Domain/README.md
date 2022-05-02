# ExpensiveMath

This application was implemented to demonstrate a use case for the virtual proxy. This application implements the [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) algorithm. This algorithm counts the number of prime numbers from 2 up to a given `n`. As it's imaginable, this computation might take a long time to complete, depending on the size of `n`. So, to make things smooth for the users, a virtual proxy was used to stand in for a `SieveOfEratosthenesCalculator` subject and return a provisional response while the computation is done at the background. As soon as a response arrives, the `SieveOfEratosthenesCalculator` will replace this provisional response with the actual list of prime numbers found.
To accomplish this, a `SieveOfEratosthenes` interface was introduced, with a method to `PrintPrimeCountUpTo(int n)`. This interface looks like this:

```csharp
namespace ExpensiveMath.Algorithms;

public interface SieveOfEratosthenes
{
  void PrintPrimeCountUpTo(int n);
}
```

And it's implemented by both `SieveOfEratosthenesCalculator` and `SieveOfEratosthenesProxy`.

The proxy's implementation keeps a reference to the real subject (i.e. `SieveOfEratosthenesCalculator`) and, whenever `PrintPrimeCountUpTo` is called, prints a message to the console saying that a result is being processed and starts a `Thread` to perform the heavy work in the background:

```csharp
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
```

The calculator's implementation contains the heavy work of computing the prime numbers:

```csharp
public class SieveOfEratosthenesCalculator : SieveOfEratosthenes
{
  protected List<int> GetPrimesUpTo(int limit)
  {
    var list = new List<int>();
    var crossedOutItems = new List<int>();
    for (int i = 2; i <= limit; i++)
    {
      list.Add(i);
    }

    list.ForEach(n =>
    {
      var result = n;
      var currentPosition = 0;
      while (result < limit && !crossedOutItems.Contains(n))
      {
        result = n * list[currentPosition];
        crossedOutItems.Add(result);
        currentPosition++;
      }
    });

    return list.Where(i => !crossedOutItems.Contains(i)).ToList();
  }

  public void PrintPrimeCountUpTo(int n)
  {
    var result = this.GetPrimesUpTo(n);
    Console.WriteLine($"Result {result.Count.ToString()}");
  }
}

```

Then, at the presentation layer, a `MathUI` interface was introduced to interact with the user and capture the input value for `n`:

```csharp
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
```

And finally, when instantiating `MathUI`, we give it an instance of the proxy instead one for the real subject:

```csharp
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

```

Now, whenever the UI is executed and the user enters a number, the proxy implementation will take place and print "Processing..." until a response is ready to be printed.
