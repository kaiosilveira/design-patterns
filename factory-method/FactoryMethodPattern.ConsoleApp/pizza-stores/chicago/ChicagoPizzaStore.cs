using FactoryMethodPattern.Pizzas;

namespace FactoryMethodPattern.PizzaStores;

public class ChicagoPizzaStore : PizzaStore
{
  protected override Pizza CreatePizza(PizzaTypes type)
  {
    return new ChicagoStyleCheesePizza();
  }
}