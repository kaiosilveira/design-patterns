namespace HouseOfTheFuture.Domain.Widgets;

public enum WidgetType
{
  ALARM,
  CLOCK
}

public interface Widget
{
  WidgetType GetWidgetType();
}