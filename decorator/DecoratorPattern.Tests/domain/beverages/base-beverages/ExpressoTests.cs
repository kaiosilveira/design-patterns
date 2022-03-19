using Xunit;
using StarbuzzCoffee.Domain.Beverages;

namespace DecoratorPattern.Tests;

public class ExpressoTest
{
  Expresso expresso;

  public ExpressoTest()
  {
    this.expresso = new Expresso();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(1.99, expresso.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Expresso", expresso.GetDescription());
  }
}