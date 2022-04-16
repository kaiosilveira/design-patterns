namespace StarbuzzCoffee.Domain.Ingredients;

public class Water
{
  public bool Boiled { get; }

  public Water(bool boiled)
  {
    Boiled = boiled;
  }
}
