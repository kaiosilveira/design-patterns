namespace HouseOfTheFuture.Domain.Widgets;

public enum WidgetType
{
  ALARM,
  CLOCK,
  SPRINKLER,
  COFFEE_POT,
  DISPLAY,
  WEATHER_MONITOR,
}

public interface Widget
{
  WidgetType GetWidgetType();
}