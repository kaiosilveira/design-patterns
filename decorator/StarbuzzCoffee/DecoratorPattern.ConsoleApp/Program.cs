using StarbuzzCoffee.Beverages;
using StarbuzzCoffee.Beverages.Condiments;

namespace StarbuzzCoffee.Program;

public class Program
{
  public static void Main(string[] args)
  {
    var expresso = new Expresso();
    Console.WriteLine($"Ordered a {expresso.GetDescription()} for ${expresso.Cost()}");

    var doubleMochaWithWhip = new Whip(new Mocha(new Mocha(new DarkRoast())));
    Console.WriteLine(
      $"Ordered a {doubleMochaWithWhip.GetDescription()} for ${doubleMochaWithWhip.Cost()}"
    );
  }
}