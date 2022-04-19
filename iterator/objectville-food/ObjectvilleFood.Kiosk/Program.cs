using ObjectvilleFood.Domain.Utils;
using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleDiner.Domain.MenuDefinition;
using ObjectvilleCafe.Domain.MenuDefinition;

namespace ObjectvilleFood.Kiosk;

public class Waitress
{
  private Menu breakfastMenu;
  private Menu lunchMenu;
  private Menu dinnerMenu;

  public Waitress(Menu breakfastMenu, Menu lunchMenu, Menu dinnerMenu)
  {
    this.breakfastMenu = breakfastMenu;
    this.lunchMenu = lunchMenu;
    this.dinnerMenu = dinnerMenu;
  }

  public void PrintMenu()
  {
    Console.WriteLine('\n' + "MENU\n----\nBREAKFAST");
    PrintMenu(breakfastMenu.CreateIterator());

    Console.WriteLine('\n' + "LUNCH");
    PrintMenu(lunchMenu.CreateIterator());

    Console.WriteLine('\n' + "DINNER");
    PrintMenu(dinnerMenu.CreateIterator());
  }

  private void PrintMenu(Iterator<MenuItem> iterator)
  {
    while (iterator.HasNext())
    {
      MenuItem menuItem = iterator.Next();
      var vegetarianText = menuItem.IsVegetarian ? "🍀" : "";
      Console.WriteLine($"{menuItem.Name}: {menuItem.Description} [{menuItem.Price}] {vegetarianText}");
    }
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var waitress = new Waitress(new PancakeHouseMenu(), new DinerMenu(), new CafeMenu());
    waitress.PrintMenu();
  }
}