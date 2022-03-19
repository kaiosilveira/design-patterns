using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Pricing;

namespace DecoratorPattern.Tests;

public class DarkRoastTest
{
  [Fact]
  public void TestPriceForSmallSize()
  {
    var smallDarkRoast = new DarkRoast(BeverageSize.TALL);
    Assert.Equal(PricingTable.DARK_ROAST, smallDarkRoast.Cost());
  }

  [Fact]
  public void TestPriceForMediumSize()
  {
    var mediumDarkRoast = new DarkRoast(BeverageSize.GRANDE);
    Assert.Equal(PricingTable.DARK_ROAST + .2, mediumDarkRoast.Cost());
  }

  [Fact]
  public void TestPriceForLargeSize()
  {
    var bigDarkRoast = new DarkRoast(BeverageSize.VENTI);
    Assert.Equal(PricingTable.DARK_ROAST + .4, bigDarkRoast.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Dark Roast Coffee", new DarkRoast().GetDescription());
  }
}