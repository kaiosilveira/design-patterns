using Xunit;
using PancakeHouse.Domain.MenuDefinition;

public class MenuTest
{
  [Fact]
  public void TestMenu()
  {
    var menu = new PancakeHouseMenu();
    Assert.Equal(4, menu.GetNumberOfItems());
  }

  [Fact]
  public void TestCreateIterator()
  {
    var menu = new PancakeHouseMenu();
    Assert.IsType<PancakeHouseMenuIterator>(menu.CreateIterator());
  }
}