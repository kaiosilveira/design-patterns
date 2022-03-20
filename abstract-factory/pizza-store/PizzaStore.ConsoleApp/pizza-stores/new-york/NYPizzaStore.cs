using PizzaStore.Pizzas;
using PizzaStore.Pizzas.Ingredients.Factories;

namespace PizzaStore.Stores;

public class NYPizzaStore : PizzaStore
{
  protected override Pizza CreatePizza(PizzaTypes type)
  {
    return new CheesePizza(new NYPizzaIngredientFactory());
  }
}