using HouseOfTheFuture.Domain.Events;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteWeatherMonitor : WeatherMonitor
{
  private int currentTemperature;
  private readonly WidgetMediator mediator;

  public ConcreteWeatherMonitor(WidgetMediator mediator)
  {
    this.mediator = mediator;
  }

  public void SetTemperature(int temp)
  {
    currentTemperature = temp;
    var e = new ApplicationEvent(
      data: currentTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    this.mediator.RegisterEvent(e);
  }

  public int GetCurrentTemperature()
  {
    return this.currentTemperature;
  }
}

