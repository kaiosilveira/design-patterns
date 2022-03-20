using PizzaStore.Pizzas;
using PizzaStore.Pizzas.Ingredients.Factories;

namespace PizzaStore.Stores;

public class ChicagoPizzaStore : PizzaStore
{
  protected override Pizza CreatePizza(PizzaTypes type)
  {
    return new CheesePizza(new ChicagoPizzaIngredientFactory());
  }
}