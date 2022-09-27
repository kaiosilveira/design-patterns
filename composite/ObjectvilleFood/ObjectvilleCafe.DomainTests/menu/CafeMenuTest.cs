using Xunit;
using ObjectvilleCafe.Domain.MenuDefinition;

namespace ObjectvilleCafe.DomainTests;

public class CafeMenuTest
{
  [Fact]
  public void TestGetNumberOfItems()
  {
    var menu = new CafeMenu();
    Assert.Equal(3, menu.GetNumberOfItems());
  }
}