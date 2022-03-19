using Xunit;
using StarbuzzCoffee.Beverages;
using StarbuzzCoffee.Beverages.Condiments;
using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Tests;

public class MochaTest
{
  [Fact]
  public void TestHasPrice()
  {
    var mocha = new Mocha(new NullBeverage());
    Assert.Equal(PricingTable.MOCHA, mocha.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    var mocha = new Mocha(new NullBeverage());
    Assert.Equal("Mocha", mocha.GetDescription());
  }

  [Fact]
  public void TestComposeItsPriceWithAnotherBeverage()
  {
    var expresso = new Expresso();
    var mocha = new Mocha(expresso);
    Assert.Equal(PricingTable.EXPRESSO + PricingTable.MOCHA, mocha.Cost());
  }
}