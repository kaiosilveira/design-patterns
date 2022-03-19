using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Pricing;

namespace DecoratorPattern.Tests;

public class DecafTest
{
  [Fact]
  public void TestPriceForSmallSize()
  {
    Assert.Equal(PricingTable.DECAF, new Decaf(BeverageSize.TALL).Cost());
  }

  [Fact]
  public void TestPriceForMediumSize()
  {
    var mediumDecaf = new Decaf(BeverageSize.GRANDE);
    Assert.Equal(PricingTable.DECAF + .2, mediumDecaf.Cost());
  }

  public void TestPriceForLargeSize()
  {
    var largeDecaf = new Decaf(BeverageSize.VENTI);
    Assert.Equal(PricingTable.DECAF + .4, largeDecaf.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Decaf", new Decaf().GetDescription());
  }
}