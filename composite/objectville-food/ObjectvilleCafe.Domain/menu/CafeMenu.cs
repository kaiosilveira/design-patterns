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
        price: 399
      )
    );

    this.Add(
      new MenuItem(
        name: "Soup of the day",
        description: "A cup of the soup of the day, with a side salad",
        isVegetarian: false,
        price: 369
      )
    );

    this.Add(
      new MenuItem(
        name: "Burrito",
        description: "A large burrito, with whole pinto beans, salsa, guacamole",
        isVegetarian: true,
        price: 429
      )
    );
  }
}
