using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleDiner.Domain.MenuDefinition;
using ObjectvilleCafe.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Visitors;

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
    var input = "";
    var currentView = "menu";
    var healthScoreVisitor = new HealthScoreVisitor();

    while (input != "q!")
    {
      if (input == "n") currentView = "healthScoreInfo";

      if (currentView == "menu")
      {
        Console.Clear();

        var allMenus = new Menu(name: "ALL MENUS", description: "All menus, combined");
        var dinerMenu = new DinerMenu();

        dinerMenu.Add(new DinerDessertMenu());
        allMenus.Add(new PancakeHouseMenu());
        allMenus.Add(dinerMenu);
        allMenus.Add(new CafeMenu());
        allMenus.Accept(healthScoreVisitor);
        var waitress = new Waitress(allMenus);

        waitress.PrintMenu();

        Console.WriteLine("");
        Console.WriteLine("- Type 'n' for health score info");
        Console.WriteLine("- Type 'q!' to quit");
      }
      else if (currentView == "healthScoreInfo")
      {
        Console.WriteLine("Health score info:");
        healthScoreVisitor.GetHealthInfoInfo().ForEach(healthInfo =>
        {
          Console.WriteLine($"{healthInfo.MenuItemName}: {healthInfo.Score}");
        });
      }

      input = Console.ReadLine();
    }
  }
}