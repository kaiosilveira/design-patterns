using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Pizzas;

public abstract class Pizza
{
  public string Name { get; private set; }
  public Dough? Dough { get; protected set; }
  public Sauce? Sauce { get; protected set; }
  public Cheese? Cheese { get; protected set; }
  public Veggies[]? Veggies { get; protected set; }
  public Pepperoni? Pepperoni { get; protected set; }
  public Clams? Clam { get; protected set; }

  public Pizza(string name)
  {
    this.Name = name;
  }

  public abstract void Prepare();

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