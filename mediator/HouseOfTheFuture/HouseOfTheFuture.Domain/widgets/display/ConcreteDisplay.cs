namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteDisplay : Display
{
  private readonly WidgetMediator mediator;
  private int? currentTemperature;
  public List<KeyValuePair<DateTime, string>> UpcomingEvents { get; private set; }

  public ConcreteDisplay(WidgetMediator mediator)
  {
    this.mediator = mediator;
    this.UpcomingEvents = new List<KeyValuePair<DateTime, string>>();
  }

  public override void SetCurrentTemperature(int temp)
  {
    this.currentTemperature = temp;
  }

  public override string DisplayTemperature()
  {
    var tempNumber = currentTemperature.HasValue ? currentTemperature.ToString() : "--";
    return $"{tempNumber} °C";
  }

  public override string DisplayUpcomingEvents()
  {
    if (this.UpcomingEvents.Count == 0) return "No upcoming events";

    var formattedEvents = this.UpcomingEvents.Select(ue =>
    {
      var datePart = ue.Key.ToString("dd/MM");
      var timePart = ue.Key.ToShortTimeString();
      return $"[{datePart}, {timePart}] {ue.Value}";
    });

    return string.Join(" | ", formattedEvents);
  }

  public override void AppendUpcomingEvent(DateTime at, string description)
  {
    this.UpcomingEvents.Add(new KeyValuePair<DateTime, string>(at, description));
  }

  public override string ShowGoodMorningMessage()
  {
    return "Good morning!";
  }
}