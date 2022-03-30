using DuckAdapter.Animals;
using DuckAdapter.Animals.Adapters;

namespace DuckAdapter.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var disguisedTurkey = new TurkeyAdapter(new WildTurkey());
    disguisedTurkey.Quack();
    disguisedTurkey.Fly();
  }
}