using Xunit;
using StarbuzzCoffee.Beverages;
using StarbuzzCoffee.Pricing;

namespace DecoratorPattern.Tests;

public class HouseBlendTest
{
  HouseBlend houseBlend;

  public HouseBlendTest()
  {
    this.houseBlend = new HouseBlend();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(PricingTable.HOUSE_BLEND, houseBlend.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("House Blend", houseBlend.GetDescription());
  }
}