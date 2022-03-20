using PizzaStore.Pizzas.Ingredients;
using Xunit;

public class FrozenClamTest
{
  [Fact]
  public void TestDescription()
  {
    Assert.Equal("Frozen Clam", new FrozenClam().Description);
  }
}