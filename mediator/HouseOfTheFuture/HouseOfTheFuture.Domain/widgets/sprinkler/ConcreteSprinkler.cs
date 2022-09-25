using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteSprinkler : Sprinkler
{
  private WidgetMediator mediator;
  private Schedule schedule;

  public ConcreteSprinkler(WidgetMediator mediator)
  {
    this.mediator = mediator;
    this.schedule = new EmptySchedule();
  }

  public override void CheckTime(DateTime time)
  {
    if (this.schedule.Matches(time))
    {
      StartIrrigation();
      var e = new ApplicationEvent(data: null, type: ApplicationEventType.IRRIGATION_STARTED);
      mediator.RegisterEvent(e);
    }
  }

  public override void SetSchedule(Schedule schedule)
  {
    this.schedule = schedule;
  }

  public override string Describe()
  {
    return schedule.Describe();
  }

  private void StartIrrigation()
  {
    Console.WriteLine("Bell ringing");
  }
}