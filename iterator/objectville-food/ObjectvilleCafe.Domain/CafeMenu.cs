using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleCafe.Domain;

public class CafeMenu : Menu
{
  private Dictionary<string, MenuItem> menuItems;

  public CafeMenu()
  {
    this.menuItems = new Dictionary<string, MenuItem>();

    this.AddItem(
      new MenuItem(
        name: "Veggie Burger and Air Fries",
        description: "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
        isVegetarian: true,
        price: 399
      )
    );

    this.AddItem(
      new MenuItem(
        name: "Soup of the day",
        description: "A cup of the soup of the day, with a side salad",
        isVegetarian: false,
        price: 369
      )
    );

    this.AddItem(
      new MenuItem(
        name: "Burrito",
        description: "A large burrito, with whole pinto beans, salsa, guacamole",
        isVegetarian: true,
        price: 429
      )
    );
  }

  public override void AddItem(MenuItem item)
  {
    this.menuItems.Add(item.Name, item);
  }

  public override int GetNumberOfItems()
  {
    return this.menuItems.Count();
  }
}
