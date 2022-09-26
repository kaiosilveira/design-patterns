namespace HouseOfTheFuture.Domain.Utils;

public class ScheduleEntry
{
  private DayOfWeek dayOfWeek;
  private int hour;
  private int minute;
  private readonly string[] DAY_NAMES = new string[] {
    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
  };

  public ScheduleEntry(DayOfWeek dayOfWeek, int hour, int minute)
  {
    this.dayOfWeek = dayOfWeek;
    this.hour = hour;
    this.minute = minute;
  }

  public string AsString(string separator = ",")
  {
    var dayName = DAY_NAMES[Convert.ToInt32(dayOfWeek)];
    var hourStr = hour.ToString().PadLeft(2, '0');
    var minuteStr = minute.ToString().PadLeft(2, '0');
    return $"{dayName}{separator} {hourStr}:{minuteStr}";
  }
}
