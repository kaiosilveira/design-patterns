using Xunit;
using PizzaStore.Pizzas.Ingredients;

public class ThickCrustDoughTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Thick Crust Dough", new ThickCrustDough().Description);
  }
}