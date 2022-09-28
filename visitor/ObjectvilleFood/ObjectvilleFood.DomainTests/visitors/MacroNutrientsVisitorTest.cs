using Xunit;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Visitors;

public class MacroNutrientsVisitorTest
{
  [Fact]
  public void TestCollectsTheMacroNutrientsOfEachMenuItem()
  {
    var menuItem1 = new MenuItem(
        name: "Waffles",
        description: "Waffles with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359,
        proteinInGams: 3.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 63.2
    );

    var menuItem2 = new MenuItem(
        name: "Hot Dog",
        description: "Simple hot dog",
        isVegetarian: false,
        price: 359,
        proteinInGams: 3.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 63.2
    );

    var visitor = new MacroNutrientsVisitor();

    visitor.VisitMenuItem(menuItem1);
    visitor.VisitMenuItem(menuItem2);

    Assert.Collection(
      visitor.GetMacroNutrientsInfo(),
      firstMacros =>
      {
        Assert.Equal(menuItem1.CarbohydratesInGrams, firstMacros.CarbohydratesInGrams);
        Assert.Equal(menuItem1.ProteinInGrams, firstMacros.ProteinInGrams);
        Assert.Equal(menuItem1.FatInGrams, firstMacros.FatInGrams);
      },
      secondMacros =>
      {
        Assert.Equal(menuItem2.CarbohydratesInGrams, secondMacros.CarbohydratesInGrams);
        Assert.Equal(menuItem2.ProteinInGrams, secondMacros.ProteinInGrams);
        Assert.Equal(menuItem2.FatInGrams, secondMacros.FatInGrams);
      }
    );
  }
}