using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Beverages.Condiments;
using StarbuzzCoffee.Domain.Pricing;

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
}