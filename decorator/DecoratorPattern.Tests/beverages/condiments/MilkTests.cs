using Xunit;
using StarbuzzCoffee.Beverages;
using StarbuzzCoffee.Beverages.Condiments;
using StarbuzzCoffee.Pricing;

namespace DecoratorPattern.Tests;

public class MilkTest
{
  [Fact]
  public void TestHasPrice()
  {
    var milk = new Milk(new NullBeverage());
    Assert.Equal(PricingTable.MILK, milk.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    var milk = new Milk(new NullBeverage());
    Assert.Equal("Milk", milk.GetDescription());
  }

  [Fact]
  public void TestComposeItsPriceWithAnotherBeverage()
  {
    var expresso = new Expresso();
    var milk = new Milk(expresso);
    Assert.Equal(PricingTable.EXPRESSO + PricingTable.MILK, milk.Cost());
  }
}