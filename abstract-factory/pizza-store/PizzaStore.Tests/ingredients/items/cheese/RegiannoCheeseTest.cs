using Xunit;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class ReggianoCheeseTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Reggiano Cheese", new ReggianoCheese().Description);
  }
}