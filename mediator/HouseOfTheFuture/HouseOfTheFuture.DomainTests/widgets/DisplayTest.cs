using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Widgets;

public class DisplayTest
{
  [Fact]
  public void TestDisplayCurrentTemperature_ReturnsDefaultIfTemperatureIsUnknown()
  {
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);

    var currentTemp = display.DisplayCurrentTemperature();

    Assert.Equal("-- °C", currentTemp);
  }
}