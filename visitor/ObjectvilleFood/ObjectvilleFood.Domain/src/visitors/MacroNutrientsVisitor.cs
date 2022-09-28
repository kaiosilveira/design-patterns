using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleFood.Domain.Visitors;


public class MacroNutrientsInfo
{
  public double ProteinInGrams { get; private set; }
  public double CarbohydratesInGrams { get; private set; }
  public double FatInGrams { get; private set; }

  public MacroNutrientsInfo(double proteinInGrams, double carbohydratesInGrams, double fatInGrams)
  {
    this.ProteinInGrams = proteinInGrams;
    this.CarbohydratesInGrams = carbohydratesInGrams;
    this.FatInGrams = fatInGrams;
  }
}

public class MacroNutrientsVisitor : Visitor
{
  private List<MacroNutrientsInfo> MacroNutrientInfos;

  public MacroNutrientsVisitor()
  {
    this.MacroNutrientInfos = new List<MacroNutrientsInfo>();
  }

  public void VisitMenu(Menu menu) { }

  public void VisitMenuItem(MenuItem item)
  {
    var info = new MacroNutrientsInfo(
      item.ProteinInGrams,
      item.CarbohydratesInGrams,
      item.FatInGrams
    );

    this.MacroNutrientInfos.Add(info);
  }

  public List<MacroNutrientsInfo> GetMacroNutrientsInfo()
  {
    return MacroNutrientInfos;
  }
}