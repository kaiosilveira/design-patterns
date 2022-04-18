using ObjectvilleFood.Domain.Utils;
using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleDiner.Domain.MenuDefinition;

namespace ObjectvilleFood.Kiosk;
public class Waitress
{
  private Menu breakfastMenu;
  private Menu lunchMenu;

  public Waitress(Menu pancakeHouseMenu, Menu dinerMenu)
  {
    this.breakfastMenu = pancakeHouseMenu;
    this.lunchMenu = dinerMenu;
  }

  public void PrintMenu()
  {
    Console.WriteLine('\n' + "MENU\n----\nBREAKFAST");
    PrintMenu(breakfastMenu.CreateIterator());

    Console.WriteLine('\n' + "LUNCH");
    PrintMenu(lunchMenu.CreateIterator());
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
    var waitress = new Waitress(new PancakeHouseMenu(), new DinerMenu());
    waitress.PrintMenu();
  }
}