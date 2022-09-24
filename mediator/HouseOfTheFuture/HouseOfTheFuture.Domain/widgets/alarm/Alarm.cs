namespace HouseOfTheFuture.Domain.Widgets;

public interface Alarm
{
  void CheckTime(DateTime time);
  string Describe();
  void Set(IList<DayOfWeek> daysOfWeek, int hour, int minute, int second);
}