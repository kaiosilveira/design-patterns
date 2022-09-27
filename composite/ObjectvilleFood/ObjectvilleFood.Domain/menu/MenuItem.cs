namespace ObjectvilleFood.Domain.MenuDefinition;

public class MenuItem : MenuComponent
{
  public MenuItem(string name, string description, bool isVegetarian, int price)
    : base(name, description, isVegetarian, price)
  { }

  public override void Print()
  {
    var vegetarianText = this.IsVegetarian ? "🍀" : "";
    Console.WriteLine($"{this.Name}: {this.Description} [{this.Price}] {vegetarianText}");
  }
}