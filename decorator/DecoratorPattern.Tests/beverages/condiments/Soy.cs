using Xunit;
using StarbuzzCoffee.Beverages;
using StarbuzzCoffee.Beverages.Condiments;
using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Tests;

public class SoyTest
{
  [Fact]
  public void TestHasPrice()
  {
    var soy = new Soy(new NullBeverage());
    Assert.Equal(PricingTable.SOY, soy.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    var soy = new Soy(new NullBeverage());
    Assert.Equal("Soy", soy.GetDescription());
  }

  [Fact]
  public void TestComposeItsPriceWithAnotherBeverage()
  {
    var expresso = new Expresso();
    var soy = new Soy(expresso);
    Assert.Equal(PricingTable.EXPRESSO + PricingTable.SOY, soy.Cost());
  }
}