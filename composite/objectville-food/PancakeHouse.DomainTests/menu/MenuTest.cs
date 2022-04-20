using Xunit;
using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;
using ObjectvilleFood.Domain.MenuDefinition;

public class MenuTest
{
  [Fact]
  public void TestGetNumberOfItems()
  {
    var menu = new PancakeHouseMenu();
    Assert.Equal(4, menu.GetNumberOfItems());
  }

  [Fact]
  public void TestCreateIterator()
  {
    var menu = new PancakeHouseMenu();
    Assert.IsAssignableFrom<Iterator<MenuItem>>(menu.CreateIterator());
  }
}