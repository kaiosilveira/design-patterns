
namespace StarbuzzCoffee.Domain.Beverages.Condiments;

public class Whip : CondimentDecorator
{
  private Beverage beverage;

  public Whip(Beverage beverage) : base()
  {
    this.Description = "Whip";
    this.beverage = beverage;
  }

  public override double Cost()
  {
    return this.beverage.Cost() + .10;
  }
}