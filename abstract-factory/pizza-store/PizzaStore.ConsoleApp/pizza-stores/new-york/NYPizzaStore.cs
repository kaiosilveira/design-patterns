using PizzaStore.Pizzas;

namespace PizzaStore.Stores;

public class NYPizzaStore : PizzaStore
{
  protected override Pizza CreatePizza(PizzaTypes type)
  {
    return new NYStyleCheesePizza();
  }
}