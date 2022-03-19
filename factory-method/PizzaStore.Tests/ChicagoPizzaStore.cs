using Xunit;
using PizzaStore.Pizzas;
using PizzaStore.Stores;

namespace PizzaStore.Tests;

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