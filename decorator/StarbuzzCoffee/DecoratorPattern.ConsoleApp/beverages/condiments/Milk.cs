using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Beverages.Condiments;

public class Milk : CondimentDecorator
{
  private Beverage beverage;

  public Milk(Beverage beverage) : base()
  {
    this.Description = "Milk";
    this.beverage = beverage;
  }

  public override double Cost()
  {
    return this.beverage.Cost() + PricingTable.MILK;
  }
}