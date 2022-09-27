using Xunit;
using PancakeHouse.Domain.MenuDefinition;

public class MenuTest
{
  [Fact]
  public void TestGetNumberOfItems()
  {
    var menu = new PancakeHouseMenu();
    Assert.Equal(4, menu.GetNumberOfItems());
  }
}