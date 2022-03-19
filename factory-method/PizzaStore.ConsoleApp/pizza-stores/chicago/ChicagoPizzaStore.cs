using PizzaStore.Pizzas;

namespace PizzaStore.Stores;

public class ChicagoPizzaStore : PizzaStore
{
  protected override Pizza CreatePizza(PizzaTypes type)
  {
    return new ChicagoStyleCheesePizza();
  }
}