using Xunit;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class MarinaraSauceTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Marinara Sauce", new MarinaraSauce().Description);
  }
}