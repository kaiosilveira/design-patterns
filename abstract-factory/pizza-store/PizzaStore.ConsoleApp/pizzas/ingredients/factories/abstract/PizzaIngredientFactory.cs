namespace PizzaStore.Pizzas.Ingredients.Factories;

public interface PizzaIngredientFactory
{
  public Dough CreateDough();
  public Sauce CreateSauce();
  public Cheese CreateCheese();
  public Veggies[] CreateVeggies();
  public Pepperoni CreatePepperoni();
  public Clams CreateClam();
}