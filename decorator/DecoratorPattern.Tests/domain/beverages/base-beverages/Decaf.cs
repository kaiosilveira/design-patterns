using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Pricing;

namespace DecoratorPattern.Tests;

public class DecafTest
{
  Decaf decaf;

  public DecafTest()
  {
    this.decaf = new Decaf();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(PricingTable.DECAF, decaf.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Decaf", decaf.GetDescription());
  }
}