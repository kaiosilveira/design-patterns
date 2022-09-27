using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleDiner.Domain.MenuDefinition;
using ObjectvilleCafe.Domain.MenuDefinition;

namespace ObjectvilleFood.Kiosk;

public class Waitress
{
  private MenuComponent allMenus;

  public Waitress(MenuComponent menus)
  {
    this.allMenus = menus;
  }

  public void PrintMenu()
  {
    allMenus.Print();
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var allMenus = new Menu(name: "ALL MENUS", description: "All menus, combined");
    var dinerMenu = new DinerMenu();

    dinerMenu.Add(new DinerDessertMenu());
    allMenus.Add(new PancakeHouseMenu());
    allMenus.Add(dinerMenu);
    allMenus.Add(new CafeMenu());

    var waitress = new Waitress(allMenus);

    waitress.PrintMenu();
  }
}