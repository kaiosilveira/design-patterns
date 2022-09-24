namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Clock : Widget
{
  public WidgetType GetWidgetType()
  {
    return WidgetType.CLOCK;
  }

  public abstract void Tick();
}