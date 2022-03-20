namespace PizzaStore.Pizzas.Ingredients;

public abstract class PizzaIngredient
{
  public string Description { get; }

  public PizzaIngredient(string description)
  {
    this.Description = description;
  }
}