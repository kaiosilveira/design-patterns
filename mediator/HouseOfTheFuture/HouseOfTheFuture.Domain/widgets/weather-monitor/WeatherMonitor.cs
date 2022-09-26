
namespace HouseOfTheFuture.Domain.Widgets;

public abstract class WeatherMonitor : Widget
{
  public abstract void SetTemperature(int temp);

  public abstract int GetCurrentTemperature();

  public WidgetType GetWidgetType()
  {
    return WidgetType.WEATHER_MONITOR;
  }
}