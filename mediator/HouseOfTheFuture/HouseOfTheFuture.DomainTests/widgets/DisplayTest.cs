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

    var currentTemp = display.DisplayTemperature();

    Assert.Equal("-- °C", currentTemp);
  }

  [Fact]
  public void TestSetTemperature_UpdatesTheCurrentTemperature()
  {
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);

    display.SetCurrentTemperature(38);
    var currentTemp = display.DisplayTemperature();

    Assert.Equal("38 °C", currentTemp);
  }
}