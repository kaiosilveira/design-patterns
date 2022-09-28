using ObjectvilleFood.Domain.Visitors;

namespace ObjectvilleFood.Domain.MenuDefinition;

public class MenuItem : MenuComponent
{
  public MenuItem(string name, string description, bool isVegetarian, int price,
    double proteinInGams, double carbohydratesInGrams, double fatInGrams,
    string healthScore = "?"
  )
    : base(
      name, description, isVegetarian, price,
      proteinInGams, carbohydratesInGrams, fatInGrams, healthScore
    )
  { }

  public override void Print()
  {
    var vegetarianText = this.IsVegetarian ? "🍀" : "";
    Console.WriteLine($"{this.Name}: {this.Description} [{this.Price}] {vegetarianText}");
  }

  public override void Accept(Visitor visitor)
  {
    visitor.VisitMenuItem(this);
  }
}