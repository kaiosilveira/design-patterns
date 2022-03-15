using FactoryMethodPattern.Pizzas;

namespace FactoryMethodPattern.PizzaStores;

public class NYPizzaStore : PizzaStore
{
  protected override Pizza CreatePizza(PizzaTypes type)
  {
    return new NYStyleCheesePizza();
  }
}