
using HouseOfTheFuture.Domain.ValueObjects;

namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Calendar : Widget
{
  public abstract void AddEvent(CalendarEvent e);

  public WidgetType GetWidgetType()
  {
    return WidgetType.CALENDAR;
  }
}