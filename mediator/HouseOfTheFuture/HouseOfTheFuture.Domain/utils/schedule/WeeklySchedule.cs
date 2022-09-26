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

  public string Describe()
  {
    var result = new List<string>();
    this.ScheduledDaysOfWeek.ToList().ForEach(day =>
    {
      var entry = new ScheduleEntry(dayOfWeek: day, hour: ScheduledHour, minute: ScheduledMinute);
      result.Add(entry.AsString(separator: ":"));
    });

    return String.Join(" | ", result);
  }

  public string DescribeMatch(DateTime time)
  {
    if (!Matches(time)) throw new NoScheduleMatchException();

    var day = this.ScheduledDaysOfWeek.Find(i => i == time.DayOfWeek);
    var entry = new ScheduleEntry(dayOfWeek: day, hour: ScheduledHour, minute: ScheduledMinute);
    return entry.AsString();
  }
}
