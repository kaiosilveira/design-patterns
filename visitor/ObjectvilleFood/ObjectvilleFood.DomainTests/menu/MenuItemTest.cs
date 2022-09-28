using Xunit;
using Moq;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Exceptions;
using ObjectvilleFood.Domain.Visitors;

namespace ObjectvilleFood.DomainTests;

class EmptyMenuItem : MenuItem
{
  public EmptyMenuItem()
    : base(
      name: "Empty Item", description: "Empty Item", isVegetarian: false, price: 0,
      proteinInGams: 3.6, carbohydratesInGrams: 125.3, fatInGrams: 63.2
    )
  { }
}

public class MenuItemTest
{
  private MenuItem menuItem;
  public MenuItemTest()
  {
    this.menuItem = new MenuItem(
        name: "Waffles",
        description: "Waffles with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359,
        proteinInGams: 3.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 63.2
    );
  }

  [Fact]
  public void TestAssignPropertiesCorrectly()
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

    Assert.Equal("Waffles", menuItem.Name);
    Assert.Equal("Waffles with your choice of blueberries or strawberries", menuItem.Description);
    Assert.True(menuItem.IsVegetarian);
    Assert.Equal(359, menuItem.Price);
    Assert.Equal(3.6, menuItem.ProteinInGrams);
    Assert.Equal(125.3, menuItem.CarbohydratesInGrams);
    Assert.Equal(63.2, menuItem.FatInGrams);
  }

  [Fact]
  public void TestAcceptsVisitor()
  {
    var visitor = new Mock<Visitor>();
    menuItem.Accept(visitor: visitor.Object);
    visitor.Verify(v => v.VisitMenuItem(menuItem), Times.Once());
  }

  [Fact]
  public void TestThrowsWhenRequestedToAdd()
  {
    Assert.Throws<UnsupportedOperationException>(() => menuItem.Add(new EmptyMenuItem()));
  }

  [Fact]
  public void TestThrowsWhenRequestedToRemove()
  {
    Assert.Throws<UnsupportedOperationException>(() => menuItem.Remove(new EmptyMenuItem()));
  }

  [Fact]
  public void TestThrowsWhenRequestedForChildren()
  {
    Assert.Throws<UnsupportedOperationException>(() => menuItem.GetChild(0));
  }
}