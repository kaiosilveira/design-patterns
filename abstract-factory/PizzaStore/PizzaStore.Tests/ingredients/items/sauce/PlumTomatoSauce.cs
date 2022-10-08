using Xunit;
using PizzaStore.Pizzas.Ingredients;

public class PlumTomatoSauceTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Plum Tomato Sauce", new PlumTomatoSauce().Description);
  }
}