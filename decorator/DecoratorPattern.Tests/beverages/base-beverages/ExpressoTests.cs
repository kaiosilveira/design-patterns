using Xunit;
using StarbuzzCoffee.Beverages;
using StarbuzzCoffee.Pricing;

namespace DecoratorPattern.Tests;

public class ExpressoTest
{
  Expresso expresso;

  public ExpressoTest()
  {
    this.expresso = new Expresso();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(PricingTable.EXPRESSO, expresso.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Expresso", expresso.GetDescription());
  }
}