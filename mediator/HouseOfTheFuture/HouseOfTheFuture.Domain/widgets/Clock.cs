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
    this.mediator.RegisterEvent(ApplicationEventType.CLOCK_TICK);
  }
}