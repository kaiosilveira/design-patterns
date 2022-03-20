using PizzaStore.Pizzas;
using PizzaStore.Stores;

namespace PizzaStore.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var nyStyleCheesePizza = new NYPizzaStore().Order(PizzaTypes.CHEESE);
    var chicagoStyleCheesePizza = new ChicagoPizzaStore().Order(PizzaTypes.CHEESE);
  }
}