namespace FactoryMethodPattern.Pizzas;

public class ChicagoStyleCheesePizza : Pizza
{
  public ChicagoStyleCheesePizza() : base(
    name: "Chicago Style Deep Dish Cheese Pizza",
    dough: "Extract Thick Crust Dough",
    sauce: "Plum Tomato Sauce",
    toppings: new List<string> { "Shredded Mozzarella Cheese" }
  )
  { }

  public override void Cut()
  {
    Console.WriteLine("Cutting the pizza into square slices");
  }
}