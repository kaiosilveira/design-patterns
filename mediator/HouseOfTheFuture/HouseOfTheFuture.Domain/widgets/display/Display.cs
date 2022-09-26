namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Display : Widget
{
  public abstract void SetCurrentTemperature(int temp);

  public abstract string ShowCurrentTemperature();

  public abstract void AppendUpcomingEvent(DateTime at, string description);

  public abstract string ShowUpcomingEvents();

  public abstract void SetCurrentDateTime(DateTime dateTime);

  public abstract void Render();

  public abstract void NotifyCoffeeReady();

  public abstract void NotifyAlarmTriggered(string alarmDescription);

  public WidgetType GetWidgetType()
  {
    return WidgetType.DISPLAY;
  }
}

