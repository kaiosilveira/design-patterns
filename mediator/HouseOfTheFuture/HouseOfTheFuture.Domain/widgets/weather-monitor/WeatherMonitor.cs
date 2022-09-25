
namespace HouseOfTheFuture.Domain.Widgets;

public abstract class WeatherMonitor : Widget
{
  public WidgetType GetWidgetType()
  {
    return WidgetType.WEATHER_MONITOR;
  }
}