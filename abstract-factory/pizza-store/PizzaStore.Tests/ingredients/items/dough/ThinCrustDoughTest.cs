using Xunit;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class ThinCrustDoughTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Thin Crust Dough", new ThinCrustDough().Description);
  }
}