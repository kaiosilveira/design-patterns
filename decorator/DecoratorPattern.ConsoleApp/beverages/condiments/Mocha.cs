using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Beverages.Condiments;

public class Mocha : CondimentDecorator
{
  private Beverage beverage;
  public Mocha(Beverage beverage) : base()
  {
    this.Description = "Mocha";
    this.beverage = beverage;
  }

  public override double Cost()
  {
    return this.beverage.Cost() + PricingTable.MOCHA;
  }
}