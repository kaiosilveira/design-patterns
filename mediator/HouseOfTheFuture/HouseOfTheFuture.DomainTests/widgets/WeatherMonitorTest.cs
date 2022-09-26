using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;
using System;

public class WeatherMonitorTest
{
  [Fact]
  public void TestSetTemperatureUpdatesCurrentTemperatureAndEmitsEvent()
  {
    var widgetHub = new Mock<WidgetHub>();
    var weatherMonitor = new ConcreteWeatherMonitor(mediator: widgetHub.Object);

    weatherMonitor.SetTemperature(38);

    Assert.Equal(38, weatherMonitor.GetCurrentTemperature());
    widgetHub
      .Verify(m => m
        .RegisterEvent(It.Is<ApplicationEvent>(e => Convert.ToInt32(e.Data) == 38 &&
          e.Type == ApplicationEventType.TEMPERATURE_CHANGED
        ))
      );
  }
}