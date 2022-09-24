namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Alarm : Widget
{
  public abstract void CheckTime(DateTime time);
  public abstract string Describe();
  public abstract void Set(IList<DayOfWeek> daysOfWeek, int hour, int minute, int second);

  public WidgetType GetWidgetType()
  {
    return WidgetType.ALARM;
  }
}