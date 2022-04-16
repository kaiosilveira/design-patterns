using Xunit;
using ObjectvilleDiner.Domain.Menu;

namespace ObjectvilleDiner.DomainTests;

public class MenuItemTest
{
  [Fact]
  public void TestAssignPropertiesCorrectly()
  {
    var menuItem = new MenuItem(
        name: "Hotdog",
        description: "A hot dog, with saurkraut, relish, onions, topped with cheese",
        isVegetarian: true,
        price: 305
    );

    Assert.Equal("Hotdog", menuItem.Name);
    Assert.Equal("A hot dog, with saurkraut, relish, onions, topped with cheese", menuItem.Description);
    Assert.True(menuItem.IsVegetarian);
    Assert.Equal(305, menuItem.Price);
  }
}
