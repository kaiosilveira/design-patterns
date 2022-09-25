using HouseOfTheFuture.Domain.ValueObjects;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteCalendar
{
  public List<CalendarEvent> AllEvents { get; private set; }
  private readonly WidgetMediator mediator;

  public ConcreteCalendar(WidgetMediator mediator)
  {
    this.AllEvents = new List<CalendarEvent>();
    this.mediator = mediator;
  }

  public void AddEvent(CalendarEvent e)
  {
    this.AllEvents.Add(e);
  }
}