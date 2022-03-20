using Xunit;
using PizzaStore.Pizzas.Ingredients.Factories;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class NYPizzaIngredientFactoryTest
{
  public NYPizzaIngredientFactory factory { get; set; }

  public NYPizzaIngredientFactoryTest()
  {
    this.factory = new NYPizzaIngredientFactory();
  }

  [Fact]
  public void TestCreateCheese()
  {
    Assert.IsType<ReggianoCheese>(factory.CreateCheese());
  }

  [Fact]
  public void TestCreateClams()
  {
    Assert.IsType<FreshClam>(factory.CreateClam());
  }

  [Fact]
  public void TestCreateDough()
  {
    Assert.IsType<ThinCrustDough>(factory.CreateDough());
  }

  [Fact]
  public void TestCreatePepperoni()
  {
    Assert.IsType<SlicedPepperoni>(factory.CreatePepperoni());
  }

  [Fact]
  public void TestCreateSauce()
  {
    Assert.IsType<MarinaraSauce>(factory.CreateSauce());
  }

  [Fact]
  public void TestCreateVeggies()
  {
    var expectedVeggies = new Veggies[] {
      new Garlic(), new Onion(), new Mushroom(), new RedPepper()
    };

    var veggies = factory.CreateVeggies();
    Assert.Equal(expectedVeggies.Length, veggies.Length);

    for (int i = 0; i < veggies.Length; i++)
    {
      var veggie = veggies[i];
      var expectedVeggie = expectedVeggies[i];
      Assert.Equal(expectedVeggie.Description, veggie.Description);
    }
  }
}