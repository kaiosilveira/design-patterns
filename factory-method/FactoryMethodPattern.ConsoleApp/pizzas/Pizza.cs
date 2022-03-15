namespace FactoryMethodPattern.Pizzas;

public abstract class Pizza
{
  public string Name { get; private set; }
  private string Dough { get; set; }
  private string Sauce { get; set; }
  private List<string> Toppings { get; set; }

  public Pizza(string name, string dough, string sauce, List<string> toppings)
  {
    this.Name = name;
    this.Dough = dough;
    this.Sauce = sauce;
    this.Toppings = toppings;
  }

  public void Prepare()
  {
    Console.WriteLine($"Preparing {this.Name}");
    Console.WriteLine("Tossing dough...");
    Console.WriteLine("Adding sauce...");
    Console.WriteLine("Adding toppings:");
    Toppings.ForEach(Topping => Console.WriteLine($"    {Topping}"));
  }

  public virtual void Bake()
  {
    Console.WriteLine("Bake for 25 minutes at 350");
  }
  public virtual void Cut()
  {
    Console.WriteLine("Cutting the pizza into diagonal slices");
  }
  public virtual void Box()
  {
    Console.WriteLine("Place the pizza in official PizzaStore box");
  }
}