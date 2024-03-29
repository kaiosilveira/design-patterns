using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteAlarm : Alarm
{
  private readonly WidgetHub mediator;
  private Schedule schedule;

  public ConcreteAlarm(WidgetHub mediator)
  {
    this.mediator = mediator;
    this.schedule = new EmptySchedule();
  }

  public override void CheckTime(DateTime time)
  {
    if (schedule.Matches(time))
    {
      var alarmText = $"It's {schedule.DescribeMatch(time)}!";
      var e = new ApplicationEvent(data: alarmText, type: ApplicationEventType.ALARM_TRIGGERED);

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