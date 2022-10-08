using Xunit;
using ObjectvilleDiner.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;
using ObjectvilleFood.Domain.MenuDefinition;

public class MenuTest
{
  [Fact]
  public void TestGetNumberOfItems()
  {
    var menu = new DinerMenu();
    Assert.Equal(6, menu.GetNumberOfItems());
  }

  [Fact]
  public void TestCreateIterator()
  {
    var menu = new DinerMenu();
    Assert.IsAssignableFrom<Iterator<MenuItem>>(menu.CreateIterator());
  }
}
