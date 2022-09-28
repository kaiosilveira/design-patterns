using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleCafe.Domain.MenuDefinition;

public class CafeMenu : Menu
{
  public CafeMenu() : base(name: "Dinner menu", description: "Objectville Cafe's dinner menu")
  {
    this.Add(
      new MenuItem(
        name: "Veggie Burger and Air Fries",
        description: "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
        isVegetarian: true,
        price: 399,
        proteinInGams: 42.6,
        carbohydratesInGrams: 135.3,
        fatInGrams: 3.2
      )
    );

    this.Add(
      new MenuItem(
        name: "Soup of the day",
        description: "A cup of the soup of the day, with a side salad",
        isVegetarian: false,
        price: 369,
        proteinInGams: 3.6,
        carbohydratesInGrams: 52.3,
        fatInGrams: 3.2
      )
    );

    this.Add(
      new MenuItem(
        name: "Burrito",
        description: "A large burrito, with whole pinto beans, salsa, guacamole",
        isVegetarian: true,
        price: 429,
        proteinInGams: 57.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 135.2
      )
    );
  }
}
