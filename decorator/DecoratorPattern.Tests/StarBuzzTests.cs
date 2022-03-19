using Xunit;
using StarbuzzCoffee.Domain.Beverages;
using StarbuzzCoffee.Domain.Beverages.Condiments;

namespace DecoratorPattern.Tests;

public class CoffeeShopTest
{
  [Fact]
  public void TestOrderAnExpressoWithNoCondiments()
  {
    var expresso = new Expresso();
    Assert.Equal(1.99, expresso.Cost());
    Assert.Equal("Expresso", expresso.GetDescription());
  }

  [Fact]
  public void TestOrderDoubleMochaWithWhip()
  {
    var whip = new Milk(new Mocha(new Mocha(new DarkRoast())));
    Assert.Equal(1.49, whip.Cost());
  }

  [Fact]
  public void TestOrderHouseBlendWithSoyMochaAndWhip()
  {
    var whip = new Whip(new Mocha(new Soy(new HouseBlend())));
    Assert.Equal(1.34, whip.Cost());
  }
}