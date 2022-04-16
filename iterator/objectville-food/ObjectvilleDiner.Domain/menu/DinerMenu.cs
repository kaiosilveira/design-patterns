namespace ObjectvilleDiner.Domain.Menu;

public class DinerMenu
{
  private const int MAX_ITEMS = 6;
  private int numberOfItems = 0;
  private MenuItem[] menuItems;

  public DinerMenu()
  {
    this.menuItems = new MenuItem[MAX_ITEMS];
    this.AddItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 299);
    this.AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 299);
    this.AddItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 329);
    this.AddItem("Hotdog", "A hot dog, with saurkraut, relish, onions, topped with cheese", false, 305);
  }

  public void AddItem(string name, string description, bool isVegetarian, int price)
  {
    if (numberOfItems >= MAX_ITEMS)
    {
      Console.WriteLine("Sorry, menu is full! Can't add item to menu");
    }
    else
    {
      MenuItem menuItem = new MenuItem(name, description, isVegetarian, price);
      menuItems[numberOfItems] = menuItem;
      numberOfItems++;
    }
  }

  public IEnumerable<MenuItem> GetMenuItems()
  {
    return this.menuItems;
  }

  public IEnumerable<MenuItem> GetVegetarianMenuItems()
  {
    return this.menuItems.Where(item => item.IsVegetarian);
  }

  public int GetNumberOfItems()
  {
    return this.menuItems.Count();
  }
}