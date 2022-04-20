using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;

namespace ObjectvilleDiner.Domain.MenuDefinition;

public class DinerMenu : Menu
{
  private const int MAX_ITEMS = 6;
  private int numberOfItems = 0;
  private MenuItem[] menuItems;

  public DinerMenu()
  {
    this.menuItems = new MenuItem[MAX_ITEMS];

    this.AddItem(
      new MenuItem(
        name: "Vegetarian BLT",
        description: "(Fakin') Bacon with lettuce & tomato on whole wheat",
        isVegetarian: true,
        price: 299
      )
    );

    this.AddItem(
      new MenuItem(
        name: "BLT",
        description: "Bacon with lettuce & tomato on whole wheat",
        isVegetarian: false,
        price: 299
      )
    );

    this.AddItem(
      new MenuItem(
        name: "Soup of the day",
        description: "Soup of the day, with a side of potato salad",
        isVegetarian: false,
        price: 329
      )
    );

    this.AddItem(
      new MenuItem(
        name: "Hotdog",
        description: "A hot dog, with saurkraut, relish, onions, topped with cheese",
        isVegetarian: false,
        price: 305
      )
    );
  }

  protected override void AddItem(MenuItem item)
  {
    if (numberOfItems >= MAX_ITEMS)
    {
      Console.WriteLine("Sorry, menu is full! Can't add item to menu");
    }
    else
    {
      menuItems[numberOfItems] = item;
      numberOfItems++;
    }
  }

  public override Iterator<MenuItem> CreateIterator()
  {
    return new DinerMenuIterator(menuItems);
  }

  public IEnumerable<MenuItem> GetVegetarianMenuItems()
  {
    return this.menuItems.Where(item => item.IsVegetarian);
  }

  public override int GetNumberOfItems()
  {
    return this.menuItems.Count();
  }
}