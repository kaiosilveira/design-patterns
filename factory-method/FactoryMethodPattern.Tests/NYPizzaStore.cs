using Xunit;
using FactoryMethodPattern.Pizzas;
using FactoryMethodPattern.PizzaStores;

namespace FactoryMethodPattern.Tests;

public class NYPizzaStoreTest
{
  [Fact]
  public void TestCreateANewYorkStylePizza()
  {
    var pizza = new NYPizzaStore().Order(PizzaTypes.CHEESE);
    Assert.IsType<NYStyleCheesePizza>(pizza);
    Assert.Equal("NY Style Sauce and Cheese Pizza", pizza.Name);
  }
}