using HouseOfTheFuture.Domain.Events;

namespace HouseOfTheFuture.Domain.Widgets;

public interface TimeProvider
{
  DateTime GetCurrentDateTime();

  bool Compare(DateTime t1, DateTime t2);
}

public class ConcreteCoffeePot
{
  public bool IsBrewing { get; private set; }
  private Mediator mediator;
  private TimeProvider timeProvider;
  private DateTime brewingStartedAt;

  public ConcreteCoffeePot(Mediator mediator, TimeProvider timeProvider)
  {
    this.IsBrewing = false;
    this.mediator = mediator;
    this.timeProvider = timeProvider;
  }

  public void StartBrewing()
  {
    IsBrewing = true;
    brewingStartedAt = timeProvider.GetCurrentDateTime();
  }

  public void CheckTime(DateTime time)
  {
    if (IsBrewing && timeProvider.Compare(time, brewingStartedAt.AddSeconds(20)))
    {
      var e = new ApplicationEvent(data: null, type: ApplicationEventType.COFFEE_READY);
      mediator.RegisterEvent(e);
      IsBrewing = false;
    }
  }
}