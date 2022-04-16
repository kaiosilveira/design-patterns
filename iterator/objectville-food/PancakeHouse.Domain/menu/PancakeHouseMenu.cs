namespace PancakeHouse.Domain.Menu;

public class PancakeHouseMenu
{
  private List<MenuItem> menuItems;

  public PancakeHouseMenu()
  {
    menuItems = new List<MenuItem>();

    AddItem("K&B's Pancake Breakfast",
      "Pancakes with scrambled eggs, and toast",
      true,
      299
    );

    AddItem("Regular Pancake Breakfast",
      "Pancakes with fried eggs, sausage",
      false,
      299
    );

    AddItem("Blueberry Pancakes",
      "Pancakes made with fresh blueberries",
      true,
      349
    );

    AddItem("Waffles",
      "Waffles, with your choice of blueberries or strawberries",
      true,
      359
    );
  }

  private void AddItem(string name, string description, bool isVegetarian, int price)
  {
    MenuItem menuItem = new MenuItem(name, description, isVegetarian, price);
    menuItems.Add(menuItem);
  }

  public IEnumerable<MenuItem> GetMenuItems()
  {
    return menuItems;
  }

  public int GetNumberOfItems()
  {
    return this.menuItems.Count();
  }
}