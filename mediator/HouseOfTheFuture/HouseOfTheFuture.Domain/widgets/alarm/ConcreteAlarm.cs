using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteAlarm : Alarm
{
  private Mediator mediator;
  private Schedule schedule;

  public ConcreteAlarm(Mediator mediator)
  {
    this.mediator = mediator;
    this.schedule = new EmptySchedule();
  }

  public override void CheckTime(DateTime time)
  {
    if (schedule.Matches(time))
    {
      RingBell();
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

  private void RingBell()
  {
    Console.WriteLine("Bell ringing");
  }
}