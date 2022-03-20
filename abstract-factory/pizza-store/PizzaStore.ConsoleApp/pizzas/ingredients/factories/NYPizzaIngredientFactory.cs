using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Pizzas.Ingredients.Factories;

public class NYPizzaIngredientFactory : PizzaIngredientFactory
{
  public Dough CreateDough()
  {
    return new ThinCrustDough();
  }

  public Sauce CreateSauce()
  {
    return new MarinaraSauce();
  }

  public Cheese CreateCheese()
  {
    return new ReggianoCheese();
  }

  public Veggies[] CreateVeggies()
  {
    return new Veggies[] { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
  }

  public Pepperoni CreatePepperoni()
  {
    return new SlicedPepperoni();
  }

  public Clams CreateClam()
  {
    return new FreshClam();
  }
}