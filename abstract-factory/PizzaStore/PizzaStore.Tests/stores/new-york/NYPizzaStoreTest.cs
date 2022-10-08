using PizzaStore.Pizzas;
using PizzaStore.Pizzas.Ingredients;
using PizzaStore.Stores;
using Xunit;

public class NYPizzaStoreTest
{
  [Fact]
  public void TestCreateCheesePizza()
  {
    var pizza = new NYPizzaStore().Order(PizzaTypes.CHEESE);
    Assert.IsType<ThinCrustDough>(pizza.Dough);
    Assert.IsType<MarinaraSauce>(pizza.Sauce);
    Assert.IsType<ReggianoCheese>(pizza.Cheese);
  }
}