namespace PizzaStore.Pizzas;

public class NYStyleCheesePizza : Pizza
{
  public NYStyleCheesePizza() : base(
    name: "NY Style Sauce and Cheese Pizza",
    dough: "Thin Crust Dough",
    sauce: "Marinara Sauce",
    toppings: new List<string> { "Grated Reggiano Cheese" }
  )
  { }
}