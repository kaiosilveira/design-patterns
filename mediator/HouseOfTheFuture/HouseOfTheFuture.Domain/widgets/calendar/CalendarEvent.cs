namespace HouseOfTheFuture.Domain.ValueObjects;

public class CalendarEvent
{
  public DateTime At { get; private set; }
  public string Description { get; private set; }

  public CalendarEvent(DateTime at, string description)
  {
    this.At = at;
    this.Description = description;
  }
}