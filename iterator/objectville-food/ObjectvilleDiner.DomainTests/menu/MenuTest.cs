using Xunit;
using ObjectvilleDiner.Domain.MenuDefinition;

public class MenuTest
{
  [Fact]
  public void TestMenu()
  {
    var menu = new DinerMenu();
    Assert.Equal(6, menu.GetNumberOfItems());
    Assert.IsType<DinerMenuIterator>(menu.CreateIterator());
  }
}
