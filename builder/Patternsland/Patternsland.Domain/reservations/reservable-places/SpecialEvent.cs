namespace Patternsland.Domain;

public class SpecialEvent : ReservableBusinessPlace
{
  public readonly DateTime Date;

  public SpecialEvent(string name, DateTime date) : base(name)
  {
    this.Date = date;
  }
}
