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
    breakfastMenu.Print();
    Console.WriteLine("\n");
    lunchMenu.Print();
    Console.WriteLine("\n");
    dinnerMenu.Print();
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