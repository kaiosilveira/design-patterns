using Xunit;
using PancakeHouse.Domain.Menu;

public class MenuTest
{
  [Fact]
  public void TestMenu()
  {
    var menu = new PancakeHouseMenu();
    Assert.Equal(4, menu.GetNumberOfItems());
  }
}