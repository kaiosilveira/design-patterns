using HouseOfTheFuture.Domain.Events;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteClock : Clock
{
  private readonly Mediator mediator;

  public ConcreteClock(Mediator mediator)
  {
    this.mediator = mediator;
  }

  public override void Tick()
  {
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);
    this.mediator.RegisterEvent(e);
  }
}