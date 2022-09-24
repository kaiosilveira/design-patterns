using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Alarm : Widget
{
  public abstract void CheckTime(DateTime time);
  public abstract string Describe();
  public abstract void SetSchedule(IList<DayOfWeek> daysOfWeek, int hour, int minute, int second);
  public abstract void SetSchedule(WeeklySchedule schedule);

  public WidgetType GetWidgetType()
  {
    return WidgetType.ALARM;
  }
}