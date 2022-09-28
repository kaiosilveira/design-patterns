using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleDiner.Domain.MenuDefinition;

public class DinerDessertMenu : Menu
{
  public DinerDessertMenu()
    : base(name: "Dessert Menu", description: "Objectville Diner's dessert menu")
  {
    this.Add(
      new MenuItem(
        name: "Apple Pie",
        description: "Apple pie with a flakey crust, topped with vanilla icecream",
        isVegetarian: true,
        price: 159,
        proteinInGams: 8.6,
        carbohydratesInGrams: 222.3,
        fatInGrams: 130.2,
        healthScore: "E"
      )
    );
  }
}