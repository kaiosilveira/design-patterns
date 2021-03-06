using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Beverages.Condiments;

public class Soy : CondimentDecorator
{
  private Beverage beverage;

  public Soy(Beverage beverage) : base()
  {
    this.Description = "Soy";
    this.beverage = beverage;
  }

  public override double Cost()
  {
    return this.beverage.Cost() + PricingTable.SOY;
  }
}