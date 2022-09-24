using HouseOfTheFuture.Domain.Events;

namespace HouseOfTheFuture.Domain.Widgets;

public class Clock
{
  private readonly Mediator mediator;

  public Clock(Mediator mediator)
  {
    this.mediator = mediator;
  }

  public void Tick()
  {
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);
    this.mediator.RegisterEvent(e);
  }
}