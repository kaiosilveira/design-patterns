using PizzaStore.Pizzas.Ingredients.Factories;

namespace PizzaStore.Pizzas;

public class CheesePizza : Pizza
{
  private PizzaIngredientFactory factory { get; set; }

  public CheesePizza(PizzaIngredientFactory factory) : base("Cheese Pizza")
  {
    this.factory = factory;
  }

  public override void Prepare()
  {
    Console.WriteLine($"Preparing {Name}");
    Dough = this.factory.CreateDough();
    Sauce = this.factory.CreateSauce();
    Cheese = this.factory.CreateCheese();
  }
}