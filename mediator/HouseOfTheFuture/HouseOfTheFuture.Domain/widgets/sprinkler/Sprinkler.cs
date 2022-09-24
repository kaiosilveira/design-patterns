using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Sprinkler : Widget
{
  public abstract void CheckTime(DateTime time);
  public abstract string Describe();

  public abstract void SetSchedule(Schedule schedule);

  public WidgetType GetWidgetType()
  {
    return WidgetType.SPRINKLER;
  }
}