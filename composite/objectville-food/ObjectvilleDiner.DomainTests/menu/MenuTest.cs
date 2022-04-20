using Xunit;
using ObjectvilleDiner.Domain.MenuDefinition;

public class MenuTest
{
  [Fact]
  public void TestGetNumberOfItems()
  {
    var menu = new DinerMenu();
    Assert.Equal(4, menu.GetNumberOfItems());
  }
}
