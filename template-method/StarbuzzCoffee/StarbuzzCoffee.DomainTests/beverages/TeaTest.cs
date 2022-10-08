using Xunit;
using StarbuzzCoffee.Domain.Beverages;

namespace StarbuzzCoffee.DomainTests;

public class TeaTest
{
  [Fact]
  public void TestPreparation()
  {
    var tea = new Tea();
    tea.Prepare();
    Assert.True(tea.WaterState.Boiled);
    Assert.True(tea.BrewState.Brewed);
    Assert.Equal("Tea Bag", tea.BrewState.BrewedWith);
    Assert.Equal(95, tea.CupState.CapacityLevel);
    Assert.Equal(1, tea.Condiments.Count);
    Assert.True(tea.Condiments.Contains("Lemon"));
  }

    [Fact]
  public void TestPreparationWithoutCondiments()
  {
    var tea = new Tea(withCondiments: false);
    tea.Prepare();
    Assert.Equal(0, tea.Condiments.Count);
  }
}