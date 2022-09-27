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
        price: 299
      )
    );

    this.Add(
      new MenuItem(
        name: "BLT",
        description: "Bacon with lettuce & tomato on whole wheat",
        isVegetarian: false,
        price: 299
      )
    );

    this.Add(
      new MenuItem(
        name: "Soup of the day",
        description: "Soup of the day, with a side of potato salad",
        isVegetarian: false,
        price: 329
      )
    );

    this.Add(
      new MenuItem(
        name: "Hotdog",
        description: "A hot dog, with saurkraut, relish, onions, topped with cheese",
        isVegetarian: false,
        price: 305
      )
    );
  }

  public IEnumerable<MenuComponent> GetVegetarianMenuItems()
  {
    return this.menuComponents.Where(item => item.IsVegetarian);
  }
}