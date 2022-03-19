using Xunit;
using StarbuzzCoffee.Domain.Beverages;

namespace DecoratorPattern.Tests;

public class DecafTest
{
  Decaf decaf;

  public DecafTest()
  {
    this.decaf = new Decaf();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(1.05, decaf.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("Decaf", decaf.GetDescription());
  }
}