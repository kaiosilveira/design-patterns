namespace StarbuzzCoffee.Domain.Primitives;

public class Cup
{
  public int CapacityLevel { get; }

  public Cup(int capacity)
  {
    CapacityLevel = capacity;
  }
}