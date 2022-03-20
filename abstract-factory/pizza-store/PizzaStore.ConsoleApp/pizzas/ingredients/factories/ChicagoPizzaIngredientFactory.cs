using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Pizzas.Ingredients.Factories;

public class ChicagoPizzaIngredientFactory : PizzaIngredientFactory
{
  public Cheese CreateCheese()
  {
    return new MozzarellaCheese();
  }

  public Clams CreateClam()
  {
    return new FrozenClam();
  }

  public Dough CreateDough()
  {
    return new ThickCrustDough();
  }

  public Pepperoni CreatePepperoni()
  {
    return new SlicedPepperoni();
  }

  public Sauce CreateSauce()
  {
    return new PlumTomatoSauce();
  }

  public Veggies[] CreateVeggies()
  {
    return new Veggies[] { new BlackOlives(), new Spinach(), new EggPlant() };
  }
}