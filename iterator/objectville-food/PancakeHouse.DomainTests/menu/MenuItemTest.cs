using Xunit;
using PancakeHouse.Domain.Menu;

namespace PancakeHouse.DomainTests;

public class MenuItemTest
{
  [Fact]
  public void TestAssignPropertiesCorrectly()
  {
    var menuItem = new MenuItem(
        name: "Waffles",
        description: "Waffles with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359
    );

    Assert.Equal("Waffles", menuItem.Name);
    Assert.Equal("Waffles with your choice of blueberries or strawberries", menuItem.Description);
    Assert.True(menuItem.IsVegetarian);
    Assert.Equal(359, menuItem.Price);
  }
}
