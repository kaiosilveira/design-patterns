using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleDiner.Domain.MenuDefinition;

public class DinerMenu : Menu
{
  public DinerMenu() : base(name: "Lunch Menu", description: "Objectville Diner's lunch menu")
  {
    this.Add(
      new MenuItem(
        name: "Vegetarian BLT",
        description: "(Fakin') Bacon with lettuce & tomato on whole wheat",
        isVegetarian: true,
        price: 299,
        proteinInGams: 3.6,
        carbohydratesInGrams: 50.3,
        fatInGrams: 84.2,
        healthScore: "A"
      )
    );

    this.Add(
      new MenuItem(
        name: "BLT",
        description: "Bacon with lettuce & tomato on whole wheat",
        isVegetarian: false,
        price: 299,
        proteinInGams: 32.6,
        carbohydratesInGrams: 173.3,
        fatInGrams: 25.2,
        healthScore: "C"
      )
    );

    this.Add(
      new MenuItem(
        name: "Soup of the day",
        description: "Soup of the day, with a side of potato salad",
        isVegetarian: false,
        price: 329,
        proteinInGams: 14.6,
        carbohydratesInGrams: 50.3,
        fatInGrams: 31.2,
        healthScore: "B"
      )
    );

    this.Add(
      new MenuItem(
        name: "Hotdog",
        description: "A hot dog, with saurkraut, relish, onions, topped with cheese",
        isVegetarian: false,
        price: 305,
        proteinInGams: 23.6,
        carbohydratesInGrams: 95.3,
        fatInGrams: 142.2,
        healthScore: "D"
      )
    );
  }

  public IEnumerable<MenuComponent> GetVegetarianMenuItems()
  {
    return this.menuComponents.Where(item => item.IsVegetarian);
  }
}