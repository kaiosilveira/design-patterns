using Xunit;
using ObjectvilleDiner.Domain.Menu;

public class MenuTest
{
  [Fact]
  public void TestMenu()
  {
    var menu = new DinerMenu();
    Assert.Equal(6, menu.GetNumberOfItems());
  }
}