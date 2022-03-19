using Xunit;
using StarbuzzCoffee.Domain.Beverages;

namespace DecoratorPattern.Tests;

public class DarkRoastTest
{
  DarkRoast darkRoast;

  public DarkRoastTest()
  {
    this.darkRoast = new DarkRoast();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(.99, darkRoast.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Dark Roast Coffee", darkRoast.GetDescription());
  }
}