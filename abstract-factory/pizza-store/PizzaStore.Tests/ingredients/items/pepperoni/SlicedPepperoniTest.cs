using Xunit;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class SlicedPepperoniTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Sliced Pepperoni", new SlicedPepperoni().Description);
  }
}