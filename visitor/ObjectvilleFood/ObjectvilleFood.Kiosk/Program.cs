using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleDiner.Domain.MenuDefinition;
using ObjectvilleCafe.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Visitors;

namespace ObjectvilleFood.Kiosk;

public class Program
{
  public static void Main(string[] args)
  {
    var input = "";
    var currentView = "menu";
    var healthScoreVisitor = new HealthScoreVisitor();
    var macroNutrientsVisitor = new MacroNutrientsVisitor();

    while (input != "q!")
    {
      if (input == "a") currentView = "menu";
      if (input == "n") currentView = "healthScoreInfo";
      if (input == "m") currentView = "macroNutrientsInfo";

      Console.Clear();

      if (currentView == "menu")
      {
        var allMenus = new Menu(name: "ALL MENUS", description: "All menus, combined");
        var dinerMenu = new DinerMenu();

        dinerMenu.Add(new DinerDessertMenu());
        allMenus.Add(new PancakeHouseMenu());
        allMenus.Add(dinerMenu);
        allMenus.Add(new CafeMenu());

        allMenus.Accept(healthScoreVisitor);
        allMenus.Accept(macroNutrientsVisitor);

        var waitress = new Waitress(allMenus);

        waitress.PrintMenu();
      }
      else if (currentView == "healthScoreInfo")
      {
        Console.WriteLine("Health score info:");
        healthScoreVisitor.GetHealthInfoInfo().ForEach(healthInfo =>
        {
          Console.WriteLine($"{healthInfo.MenuItemName}: {healthInfo.Score}");
        });
      }
      else if (currentView == "macroNutrientsInfo")
      {
        Console.WriteLine("Macros info:");
        macroNutrientsVisitor.GetMacroNutrientsInfo().ForEach(macro =>
        {
          Console.Write($"{macro.MenuItemName}: ");
          Console.Write($"{macro.ProteinInGrams}g protein, ");
          Console.Write($"{macro.CarbohydratesInGrams}g carbs, ");
          Console.Write($"{macro.FatInGrams}g fat");
          Console.WriteLine();
        });
      }

      Console.WriteLine("");
      Console.WriteLine("- Type 'a' for the complete menu");
      Console.WriteLine("- Type 'n' for health score info");
      Console.WriteLine("- Type 'm' for macro nutrients info");
      Console.WriteLine("- Type 'q!' to quit");

      input = Console.ReadLine();
    }
  }
}