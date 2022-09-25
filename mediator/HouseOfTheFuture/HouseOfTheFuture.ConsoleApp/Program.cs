using HouseOfTheFuture.Domain.Widgets;

public class Program
{
  public static void Main(string[] args)
  {
    var mediator = new ConcreteWidgetMediator();
    ConcreteAlarm alarm = new ConcreteAlarm(mediator);
    ConcreteClock clock = new ConcreteClock(mediator);
    ConcreteDisplay display = new ConcreteDisplay(mediator);

    mediator.AddWidget(alarm);
    mediator.AddWidget(clock);
    mediator.AddWidget(display);

    while (true)
    {
      Thread.Sleep(100);
      clock.Tick();
      display.Render();
    }
  }
}