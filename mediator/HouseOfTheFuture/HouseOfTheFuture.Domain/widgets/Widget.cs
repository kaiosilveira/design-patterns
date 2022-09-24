namespace HouseOfTheFuture.Domain.Widgets;

public enum WidgetType
{
  ALARM,
  CLOCK,
  SPRINKLER
}

public interface Widget
{
  WidgetType GetWidgetType();
}