using Xunit;
using FactoryMethodPattern.Pizzas;
using FactoryMethodPattern.PizzaStores;

namespace FactoryMethodPattern.Tests;

public class ChicagoPizzaStoreTest
{
  [Fact]
  public void TestCreateAChicagoStylePizza()
  {
    var pizza = new ChicagoPizzaStore().Order(PizzaTypes.CHEESE);
    Assert.IsType<ChicagoStyleCheesePizza>(pizza);
    Assert.Equal("Chicago Style Deep Dish Cheese Pizza", pizza.Name);
  }
}