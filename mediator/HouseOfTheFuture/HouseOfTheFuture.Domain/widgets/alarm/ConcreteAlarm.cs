using HouseOfTheFuture.Domain.Events;

namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteAlarm : Alarm
{
  private Mediator mediator;
  private IList<DayOfWeek> daysOfWeek;
  private int hour;
  private int minute;
  private int second;
  private readonly string[] DAY_NAMES = new string[] {
    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
  };

  public ConcreteAlarm(Mediator mediator)
  {
    this.mediator = mediator;
    this.daysOfWeek = new List<DayOfWeek>();
  }

  public override void CheckTime(DateTime time)
  {
    if (
      daysOfWeek.Contains(time.DayOfWeek)
      && time.Hour == hour
      && time.Minute == minute
      && time.Second == second
    )
    {
      RingBell();
      mediator.RegisterEvent(ApplicationEventType.ALARM_TRIGGERED);
    }
  }

  public override string Describe()
  {
    var result = new List<string>();
    this.daysOfWeek.ToList().ForEach(day =>
    {
      var dayName = DAY_NAMES[Convert.ToInt32(day)];
      var hourStr = hour.ToString().PadLeft(2, '0');
      var minuteStr = minute.ToString().PadLeft(2, '0');
      result.Add($"{dayName}: {hourStr}:{minuteStr}");
    });

    return String.Join(" | ", result);
  }

  public override void Set(IList<DayOfWeek> daysOfWeek, int hour, int minute, int second)
  {
    this.daysOfWeek = daysOfWeek;
    this.hour = hour;
    this.minute = minute;
    this.second = second;
  }

  private void RingBell()
  {
    Console.WriteLine("Bell ringing");
  }
}