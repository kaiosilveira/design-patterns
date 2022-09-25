using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.ValueObjects;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteCalendar : Calendar
{
  public List<CalendarEvent> AllEvents { get; private set; }
  private readonly WidgetMediator mediator;

  public ConcreteCalendar(WidgetMediator mediator)
  {
    this.AllEvents = new List<CalendarEvent>();
    this.mediator = mediator;
  }

  public override void AddEvent(CalendarEvent e)
  {
    this.AllEvents.Add(e);
    var upcomingEvent = new ApplicationEvent(
      data: e, type: ApplicationEventType.NEW_UPCOMING_EVENT
    );

    this.mediator.RegisterEvent(upcomingEvent);
  }
}