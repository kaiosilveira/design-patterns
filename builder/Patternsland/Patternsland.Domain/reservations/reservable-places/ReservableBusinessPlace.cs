namespace Patternsland.Domain;

public abstract class ReservableBusinessPlace
{
  public readonly string Name;

  public ReservableBusinessPlace(string name)
  {
    this.Name = name;
  }
}
