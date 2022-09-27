using Xunit;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Exceptions;

namespace ObjectvilleFood.DomainTests;

class EmptyMenuItem : MenuItem
{
  public EmptyMenuItem()
    : base(name: "Empty Item", description: "Empty Item", isVegetarian: false, price: 0)
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
        price: 359
    );
  }

  [Fact]
  public void TestAssignPropertiesCorrectly()
  {
    Assert.Equal("Waffles", menuItem.Name);
    Assert.Equal("Waffles with your choice of blueberries or strawberries", menuItem.Description);
    Assert.True(menuItem.IsVegetarian);
    Assert.Equal(359, menuItem.Price);
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