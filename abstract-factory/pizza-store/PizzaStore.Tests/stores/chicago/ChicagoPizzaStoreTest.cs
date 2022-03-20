using PizzaStore.Pizzas;
using PizzaStore.Pizzas.Ingredients;
using PizzaStore.Stores;
using Xunit;

public class ChicagoPizzaStoreTest
{
  [Fact]
  public void TestCreateCheesePizza()
  {
    var pizza = new ChicagoPizzaStore().Order(PizzaTypes.CHEESE);
    Assert.IsType<ThickCrustDough>(pizza.Dough);
    Assert.IsType<PlumTomatoSauce>(pizza.Sauce);
    Assert.IsType<MozzarellaCheese>(pizza.Cheese);
  }
}