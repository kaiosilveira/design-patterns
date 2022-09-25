namespace HouseOfTheFuture.Domain.Widgets;

public enum WidgetType
{
  ALARM,
  CLOCK,
  SPRINKLER,
  COFFEE_POT,
}

public interface Widget
{
  WidgetType GetWidgetType();
}