using Xunit;
using ObjectvilleCafe.Domain;
using ObjectvilleFood.Domain.Utils;
using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleCafe.DomainTests;

public class CafeMenuTest
{
  [Fact]
  public void TestGetNumberOfItems()
  {
    var menu = new CafeMenu();
    Assert.Equal(3, menu.GetNumberOfItems());
  }

  [Fact]
  public void TestCreateIterator()
  {
    var menu = new CafeMenu();
    var iterator = menu.CreateIterator();
    Assert.IsAssignableFrom<Iterator<MenuItem>>(iterator);
  }
}