using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteAlarm : Alarm
{
  private readonly WidgetMediator mediator;
  private Schedule schedule;

  public ConcreteAlarm(WidgetMediator mediator)
  {
    this.mediator = mediator;
    this.schedule = new EmptySchedule();
  }

  public override void CheckTime(DateTime time)
  {
    if (schedule.Matches(time))
    {
      var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
      mediator.RegisterEvent(e);
    }
  }

  public override string Describe()
  {
    return schedule.Describe();
  }

  public override void SetSchedule(Schedule schedule)
  {
    this.schedule = schedule;
  }
}