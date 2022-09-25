namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Display : Widget
{
  public abstract void SetCurrentTemperature(int temp);

  public abstract string DisplayTemperature();

  public abstract void AppendUpcomingEvent(DateTime at, string description);

  public abstract string DisplayUpcomingEvents();
  public abstract string ShowGoodMorningMessage();

  public WidgetType GetWidgetType()
  {
    return WidgetType.DISPLAY;
  }
}

