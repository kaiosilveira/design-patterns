using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;

namespace PancakeHouse.Domain.MenuDefinition;

public class PancakeHouseMenu : Menu
{
  private List<MenuItem> menuItems;

  public PancakeHouseMenu()
  {
    menuItems = new List<MenuItem>();

    AddItem(
      new MenuItem(
        name: "K&B's Pancake Breakfast",
        description: "Pancakes with scrambled eggs, and toast",
        isVegetarian: true,
        price: 299
      )
    );

    AddItem(
      new MenuItem(
        name: "Regular Pancake Breakfast",
        description: "Pancakes with fried eggs, sausage",
        isVegetarian: false,
        price: 299
      )
    );

    AddItem(
      new MenuItem(
        name: "Blueberry Pancakes",
        description: "Pancakes made with fresh blueberries",
        isVegetarian: true,
        price: 349
      )
    );

    AddItem(
      new MenuItem(
        name: "Waffles",
        description: "Waffles, with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359
      )
    );
  }

  protected override void AddItem(MenuItem item)
  {
    menuItems.Add(item);
  }

  public override Iterator<MenuItem> CreateIterator()
  {
    return new PancakeHouseMenuIterator(menuItems);
  }

  public override int GetNumberOfItems()
  {
    return this.menuItems.Count();
  }
}