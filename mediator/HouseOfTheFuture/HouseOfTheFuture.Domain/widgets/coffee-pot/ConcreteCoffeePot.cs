using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteCoffeePot : CoffeePot
{
  public bool IsBrewing { get; private set; }
  private readonly WidgetMediator mediator;
  private readonly TimeProvider timeProvider;
  private DateTime brewingStartedAt;

  public ConcreteCoffeePot(WidgetMediator mediator, TimeProvider timeProvider)
  {
    this.IsBrewing = false;
    this.mediator = mediator;
    this.timeProvider = timeProvider;
  }

  public override void StartBrewing()
  {
    IsBrewing = true;
    brewingStartedAt = timeProvider.GetCurrentDateTime();
  }

  public override void CheckTime(DateTime time)
  {
    if (IsBrewing && timeProvider.Compare(time, brewingStartedAt.AddSeconds(5)))
    {
      var e = new ApplicationEvent(data: null, type: ApplicationEventType.COFFEE_READY);
      mediator.RegisterEvent(e);
      IsBrewing = false;
    }
  }
}