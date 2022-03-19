using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Pricing;

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
    Assert.Equal(PricingTable.DARK_ROAST, darkRoast.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Dark Roast Coffee", darkRoast.GetDescription());
  }
}