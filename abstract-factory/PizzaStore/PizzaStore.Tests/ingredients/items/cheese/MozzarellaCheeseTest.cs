using Xunit;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class MozzarellaCheeseTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Mozzarella Cheese", new MozzarellaCheese().Description);
  }
}