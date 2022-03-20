using PizzaStore.Pizzas.Ingredients.Factories;

namespace PizzaStore.Pizzas;

public class ClamPizza : Pizza
{
  private PizzaIngredientFactory factory { get; set; }

  public ClamPizza(PizzaIngredientFactory factory) : base("Clam Pizza")
  {
    this.factory = factory;
  }

  public override void Prepare()
  {
    Console.WriteLine($"Preparing {Name}");
    Dough = this.factory.CreateDough();
    Sauce = this.factory.CreateSauce();
    Cheese = this.factory.CreateCheese();
    Clam = this.factory.CreateClam();
  }
}