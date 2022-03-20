using PizzaStore.Pizzas.Ingredients;
using Xunit;

public class FreshClamTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Fresh Clam", new FreshClam().Description);
  }
}