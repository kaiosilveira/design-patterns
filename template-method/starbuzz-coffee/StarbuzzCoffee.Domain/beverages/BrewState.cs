namespace StarbuzzCoffee.Domain.Beverages;

public class BrewState
{
  public bool Brewed { get; }
  public string BrewedWith { get; }

  public BrewState(bool brewed, string brewedWith)
  {
    Brewed = brewed;
    BrewedWith = brewedWith;
  }
}