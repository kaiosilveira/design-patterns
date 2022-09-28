using Xunit;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Visitors;

public class HealthScoreVisitorTest
{
  [Fact]
  public void TestAddsQuestionMarkAsScoreIfNoInfoIsFound()
  {
    var menuItem = new MenuItem(
        name: "Waffles",
        description: "Waffles with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359,
        proteinInGams: 3.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 63.2
    );

    var visitor = new HealthScoreVisitor();
    visitor.VisitMenuItem(menuItem);

    Assert.Single(visitor.GetHealthInfoInfo());
    Assert.Equal("?", visitor.GetHealthInfoInfo()[0].Score);
  }

  [Fact]
  public void TestCollectsTheHealthScoreOfMenuItems()
  {
    var menuItem = new MenuItem(
        name: "Waffles",
        description: "Waffles with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359,
        proteinInGams: 3.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 63.2,
        healthScore: "E"
    );

    var visitor = new HealthScoreVisitor();
    visitor.VisitMenuItem(menuItem);

    Assert.Single(visitor.GetHealthInfoInfo());
    Assert.Equal(menuItem.HealthScore, visitor.GetHealthInfoInfo()[0].Score);
  }
}
