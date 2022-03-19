namespace StarbuzzCoffee.Domain.Beverages.Condiments;

public class CondimentDecorator : Beverage
{
  public CondimentDecorator() : base() { }

  public override double Cost()
  {
    return Double.PositiveInfinity;
  }
}