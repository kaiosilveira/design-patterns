using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Beverages.Condiments;
using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Tests;

public class WhipTest
{
  [Fact]
  public void TestHasPrice()
  {
    var whip = new Whip(new NullBeverage());
    Assert.Equal(PricingTable.WHIP, whip.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    var whip = new Whip(new NullBeverage());
    Assert.Equal("Whip", whip.GetDescription());
  }

  [Fact]
  public void TestComposeItsPriceWithAnotherBeverage()
  {
    var expresso = new Expresso();
    var whip = new Whip(expresso);
    Assert.Equal(PricingTable.EXPRESSO + PricingTable.WHIP, whip.Cost());
  }
}