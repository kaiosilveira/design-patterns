using Xunit;
using PizzaStore.Pizzas.Ingredients.Factories;
using PizzaStore.Pizzas.Ingredients;

namespace PizzaStore.Tests;

public class ChicagoPizzaIngredientFactoryTest
{
  public ChicagoPizzaIngredientFactory factory { get; set; }

  public ChicagoPizzaIngredientFactoryTest()
  {
    this.factory = new ChicagoPizzaIngredientFactory();
  }

  [Fact]
  public void TestCreateCheese()
  {
    Assert.IsType<MozzarellaCheese>(factory.CreateCheese());
  }

  [Fact]
  public void TestCreateClams()
  {
    Assert.IsType<FrozenClam>(factory.CreateClam());
  }

  [Fact]
  public void TestCreateDough()
  {
    Assert.IsType<ThickCrustDough>(factory.CreateDough());
  }

  [Fact]
  public void TestCreatePepperoni()
  {
    Assert.IsType<SlicedPepperoni>(factory.CreatePepperoni());
  }

  [Fact]
  public void TestCreateSauce()
  {
    Assert.IsType<PlumTomatoSauce>(factory.CreateSauce());
  }

  [Fact]
  public void TestCreateVeggies()
  {
    var expectedVeggies = new Veggies[] { new BlackOlives(), new Spinach(), new EggPlant() };

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