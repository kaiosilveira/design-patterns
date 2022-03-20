using PizzaStore.Pizzas;

namespace PizzaStore.Stores;

public abstract class PizzaStore
{
  protected abstract Pizza CreatePizza(PizzaTypes type);

  public Pizza Order(PizzaTypes type)
  {
    var pizza = CreatePizza(type);
    pizza.Prepare();
    pizza.Bake();
    pizza.Cut();
    pizza.Box();
    return pizza;
  }
}