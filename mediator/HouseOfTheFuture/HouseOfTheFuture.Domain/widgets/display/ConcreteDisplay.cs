namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteDisplay : Display
{
  private readonly WidgetHub mediator;
  private int? currentTemperature;
  public DateTime CurrentDateTime { get; private set; }
  public List<string> Notifications { get; private set; }
  public List<KeyValuePair<DateTime, string>> UpcomingEvents { get; private set; }

  public ConcreteDisplay(WidgetHub mediator)
  {
    this.mediator = mediator;
    this.CurrentDateTime = DateTime.Now;
    this.UpcomingEvents = new List<KeyValuePair<DateTime, string>>();
    this.Notifications = new List<string>();
  }

  public override void SetCurrentTemperature(int temp)
  {
    this.currentTemperature = temp;
  }

  public override string ShowCurrentTemperature()
  {
    var tempNumber = currentTemperature.HasValue ? currentTemperature.ToString() : "--";
    return $"{tempNumber} °C";
  }

  public override string ShowUpcomingEvents()
  {
    if (this.UpcomingEvents.Count == 0) return "No upcoming events";

    var formattedEvents = this.UpcomingEvents.Select(ue =>
    {
      var datePart = ue.Key.ToString("dd/MM");
      var timePart = ue.Key.ToShortTimeString();
      return $"[{datePart}, {timePart}] {ue.Value}";
    });

    return string.Join("\n", formattedEvents);
  }

  public override void AppendUpcomingEvent(DateTime at, string description)
  {
    this.UpcomingEvents.Add(new KeyValuePair<DateTime, string>(at, description));
  }

  public override string ShowGoodMorningMessage()
  {
    return "Good morning!";
  }

  public override void SetCurrentDateTime(DateTime dateTime)
  {
    this.CurrentDateTime = dateTime;
  }

  public override void Render()
  {
    Console.Clear();

    var datePart = CurrentDateTime.ToLongDateString();
    var timePart = CurrentDateTime.ToLongTimeString();

    Console.WriteLine($"{datePart}, {timePart} | {ShowCurrentTemperature()}");
    Console.WriteLine();
    Console.WriteLine($"{ShowUpcomingEvents()}");
    Console.WriteLine();
    Console.WriteLine($"{ShowNotifications()}");
    Console.WriteLine();
    Console.WriteLine("- Press E to add a new calendar item");
  }

  public override void NotifyCoffeeReady()
  {
    var msg = "Coffee is ready!";
    this.Notifications.Add(msg);
  }

  public override void NotifyAlarmTriggered(string alarmDescription)
  {
    this.Notifications.Add(alarmDescription);
  }

  public string ShowNotifications()
  {
    if (Notifications.Count == 0) return "No new notifications";

    var notifications = String.Join("\n", Notifications);
    return $"Notifications:\n{notifications}";
  }
}