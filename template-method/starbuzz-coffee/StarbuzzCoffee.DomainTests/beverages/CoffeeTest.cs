using Xunit;
using StarbuzzCoffee.Domain.Beverages;

namespace StarbuzzCoffee.DomainTests;

public class CoffeeTest
{
  [Fact]
  public void TestPreparation()
  {
    var coffee = new Coffee();
    coffee.Prepare();
    Assert.True(coffee.WaterState.Boiled);
    Assert.True(coffee.BrewState.Brewed);
    Assert.Equal("Coffee Grinds", coffee.BrewState.BrewedWith);
    Assert.Equal(95, coffee.CupState.CapacityLevel);
    Assert.Equal(2, coffee.Condiments.Count);
    Assert.True(coffee.Condiments.Contains("Sugar"));
    Assert.True(coffee.Condiments.Contains("Milk"));
  }

  [Fact]
  public void TestPreparationWithoutCondiments()
  {
    var coffee = new Coffee(withCondiments: false);
    coffee.Prepare();
    Assert.Equal(0, coffee.Condiments.Count);
  }
}