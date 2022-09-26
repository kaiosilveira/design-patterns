using HouseOfTheFuture.Domain.Events;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteClock : Clock
{
  private readonly WidgetHub mediator;

  public ConcreteClock(WidgetHub mediator)
  {
    this.mediator = mediator;
  }

  public override void Tick()
  {
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);
    this.mediator.RegisterEvent(e);
  }
}