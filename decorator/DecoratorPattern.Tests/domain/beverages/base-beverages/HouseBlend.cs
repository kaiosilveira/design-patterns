using Xunit;
using StarbuzzCoffee.Domain.Beverages;

namespace DecoratorPattern.Tests;

public class HouseBlendTest
{
  HouseBlend houseBlend;

  public HouseBlendTest()
  {
    this.houseBlend = new HouseBlend();
  }

  [Fact]
  public void TestHasPrice()
  {
    Assert.Equal(.89, houseBlend.Cost());
  }

  [Fact]
  public void TestHasDescription()
  {
    Assert.Equal("House Blend", houseBlend.GetDescription());
  }
}