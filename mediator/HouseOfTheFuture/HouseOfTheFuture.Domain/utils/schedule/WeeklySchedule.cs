namespace HouseOfTheFuture.Domain.Utils;

public class WeeklySchedule : Schedule
{
  public List<DayOfWeek> ScheduledDaysOfWeek { get; private set; }
  public int ScheduledHour { get; private set; }
  public int ScheduledMinute { get; private set; }
  public int ScheduledSecond { get; private set; }
  private readonly string[] DAY_NAMES = new string[] {
    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
  };

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
      var dayName = DAY_NAMES[Convert.ToInt32(day)];
      var hourStr = ScheduledHour.ToString().PadLeft(2, '0');
      var minuteStr = ScheduledMinute.ToString().PadLeft(2, '0');
      result.Add($"{dayName}: {hourStr}:{minuteStr}");
    });

    return String.Join(" | ", result);
  }

  public string DescribeMatch(DateTime time)
  {
    if (!Matches(time)) throw new NoScheduleMatchException();

    var day = this.ScheduledDaysOfWeek.Find(i => i == time.DayOfWeek);
    var dayName = DAY_NAMES[Convert.ToInt32(day)];
    var hourStr = ScheduledHour.ToString().PadLeft(2, '0');
    var minuteStr = ScheduledMinute.ToString().PadLeft(2, '0');
    return $"{dayName}, {hourStr}:{minuteStr}";
  }
}