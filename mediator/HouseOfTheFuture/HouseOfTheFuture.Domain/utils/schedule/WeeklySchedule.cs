namespace HouseOfTheFuture.Domain.Utils;

public class WeeklySchedule : Schedule
{
  public List<DayOfWeek> ScheduledDaysOfWeek { get; private set; }
  public int ScheduledHour { get; private set; }
  public int ScheduledMinute { get; private set; }
  public int ScheduledSecond { get; private set; }

  public WeeklySchedule(List<DayOfWeek> daysOfWeek, int hour, int minute, int second)
  {
    ScheduledDaysOfWeek = daysOfWeek;
    ScheduledHour = hour;
    ScheduledMinute = minute;
    ScheduledSecond = second;
  }

  public bool Matches(DateTime time)
  {
    return ScheduledDaysOfWeek.Contains(time.DayOfWeek)
      && time.Hour == ScheduledHour
      && time.Minute == ScheduledMinute
      && time.Second == ScheduledSecond;
  }
}